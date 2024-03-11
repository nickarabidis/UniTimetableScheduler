using System;
using System.Collections.Generic;
using System.Linq;


namespace Scheduler.Model
{
	// Schedule chromosome
	public class Schedule : Chromosome<Schedule>
	{
		// Initializes chromosomes with configuration block (setup of chromosome)
		public Schedule(Configuration configuration)
		{
			Configuration = configuration;
			Fitness = 0;

			// reserve space for time-space slots in chromosomes code
			Slots = new List<CourseClass>[Constant.DAYS_NUM * Constant.DAY_HOURS * Configuration.NumberOfSemesters];
			for(int i=0; i< Slots.Length; ++i)
				Slots[i] = new();
			//Console.WriteLine("slots: " + Slots);
			Classes = new();

			// reserve space for flags of class requirements
			Criteria = new bool[Configuration.NumberOfCourseClasses * Model.Criteria.Weights.Length];
			
			// increment value when criteria violation occurs
			Objectives = new double[Model.Criteria.Weights.Length];
		}

		// Copy constructor
		private Schedule Copy(Schedule c, bool setupOnly)
		{
			if (!setupOnly)
			{
				// copy code
				Slots = c.Slots.ToArray();
				Classes = new(c.Classes);

				// copy flags of class requirements
				Criteria = c.Criteria.ToArray();

				// copy fitness
				Fitness = c.Fitness;
				
				Configuration = c.Configuration;
				return this;
			}
			return new Schedule(c.Configuration);
		}

		// Makes new chromosome with same setup but with randomly chosen code
		public Schedule MakeNewFromPrototype(List<float> positions = null)
		{
			// copy chromosome setup
			var newChromosome = Copy(this, true);

			// place classes at random position
			var classes = Configuration.CourseClasses;
			int nsemester = Configuration.NumberOfSemesters;
			foreach (var c in classes)
			{
				// determine random position of class
				int dur = c.Duration;
				bool lab = c.LabRequired;
				
				int semester = 0;
                int day = 0;
                int startTime = 0;
				int room = 0;

				// assigns semester of class
                semester = c.Semester.Id;
                Console.WriteLine("Semester: " + semester);

                // assigns day of class or random day
                if (c.Days is List<Day>)
				{
                    if (c.Days.Count > 1)
                    {
                        var random = new Random();
                        int randomIndex = random.Next(c.Days.Count);
                        var randomDay = c.Days[randomIndex];
                        day = randomDay.Id;

                        c.FinalDays = randomDay;
                    }
                    else
                    {
                        if (c.Days.Count > 0)
                        {
                            foreach (var dayObj in c.Days)
                            {
                                day = dayObj.Id;
                                c.FinalDays = dayObj;
                            }
                        }
                        else
                        {
                            Day randomDay = Configuration.AddRandomDay();
                            day = randomDay.Id;

                            c.FinalDays = randomDay;
                        }
                    }
                }

                // assigns startTime of class or random startTime
                if (c.StartTimes is List<StartTime>)
                {

                    if (c.StartTimes.Count > 1)
                    {
                        var random = new Random();
                        int randomIndex = random.Next(c.StartTimes.Count);
                        var randomStartTime = c.StartTimes[randomIndex];
                        startTime = randomStartTime.Id;

                        c.FinalStartTimes = randomStartTime;
                    }
                    else
                    {
                        if (c.StartTimes.Count > 0)
                        {
                            foreach (var startTimeObj in c.StartTimes)
                            {
                                startTime = startTimeObj.Id;
                                c.FinalStartTimes = startTimeObj;
                            }
                        }
                        else
                        {
                            StartTime randomStartTime = Configuration.AddRandomStartTime(dur);
                            startTime = randomStartTime.Id;

                            c.FinalStartTimes = randomStartTime;
                        }
                    }
                }

                // assigns room of class or random room
                if (c.Rooms is List<Room>)
                {
                    
                    if (c.Rooms.Count > 1)
                    {
                        var random = new Random();
                        int randomIndex = random.Next(c.Rooms.Count);
                        var randomRoom = c.Rooms[randomIndex];
                        room = randomRoom.Id;

                        c.FinalRooms = randomRoom;
                        
                    }
                    else
                    {
                        if (c.Rooms.Count > 0)
                        {
                            foreach (var roomObj in c.Rooms)
                            {
                                room = roomObj.Id;
                                c.FinalRooms = roomObj;
                            }
                        }
                        else
                        {

                            if (!c.LabRequired)
                            {
                                Room randomRoom = Configuration.AddRandomRoomTheory(semester);
                                room = randomRoom.Id;
                                
                                c.FinalRooms = randomRoom;
                            }
                            else
                            {
                                Room randomRoom = Configuration.AddRandomRoomLab();
                                room = randomRoom.Id;

                                c.FinalRooms = randomRoom;
                            }
                        }
                    }
                }


                var reservation = Reservation.GetReservation(nsemester, day, startTime, semester);


                if (positions != null)
				{
					positions.Add(reservation.Day * 1.0f);
					positions.Add(reservation.Semester * 1.0f);
					positions.Add(reservation.Time * 1.0f);
				}

				// fill time-space slots, for each hour of class
				for (int i = dur - 1; i >= 0; --i)
					newChromosome.Slots[reservation.GetHashCode() + i].Add(c);

				// insert in class table of chromosome
				newChromosome.Classes[c] = reservation.GetHashCode();
			}

			newChromosome.CalculateFitness();
			return newChromosome;
		}


		// Performes crossover operation using to chromosomes and returns pointer to offspring
		public Schedule Crossover(Schedule parent2, int numberOfCrossoverPoints, float crossoverProbability)
		{
			// check probability of crossover operation
			if (Configuration.Rand() % 100 > crossoverProbability)
				// no crossover, just copy first parent
				return Copy(this, false);

			// new chromosome object, copy chromosome setup
			var n = Copy(this, true);

			// number of classes
			var size = Classes.Count;

			var cp = new bool[size];

			// determine crossover point (randomly)
			for (int i = numberOfCrossoverPoints; i > 0; --i)
			{
				for(; ;)
				{
					int p = Configuration.Rand() % size;
					if (!cp[p])
					{
						cp[p] = true;
						break;
					}
				}
			}

			// make new code by combining parent codes
			bool first = Configuration.Rand() % 2 == 0;
			for (int i = 0; i < size; ++i)
			{
				if (first)
				{
					var courseClass = Classes.Keys.ElementAt(i);
					var reservation = Classes[courseClass];
					// insert class from first parent into new chromosome's class table
					n.Classes[courseClass] = reservation;
					// all time-space slots of class are copied
					for (int j = courseClass.Duration - 1; j >= 0; --j)
						n.Slots[reservation.GetHashCode() + j].Add(courseClass);
				}
				else
				{
					var courseClass = parent2.Classes.Keys.ElementAt(i);
					var reservation = parent2.Classes[courseClass];
					// insert class from second parent into new chromosome's class table
					n.Classes[courseClass] = reservation;
					// all time-space slots of class are copied
					for (int j = courseClass.Duration - 1; j >= 0; --j)
						n.Slots[reservation.GetHashCode() + j].Add(courseClass);
				}

				// crossover point
				if (cp[i])
					// change source chromosome
					first = !first;
			}

			n.CalculateFitness();

			// return smart pointer to offspring
			return n;
		}
		

		private void Repair(CourseClass cc1, int reservation1_index, Reservation reservation2)
		{

            var dur = cc1.Duration;
            var nsemester = Configuration.NumberOfSemesters;

			if(reservation1_index > -1) {
				for (int j = dur - 1; j >= 0; --j)
				{
					// remove class hour from current time-space slot
					var cl = Slots[reservation1_index + j];
					cl.RemoveAll(cc => cc == cc1);
				}
			}

			if (reservation2 == null)
			{

				int semester = 0;
				int day = 0;
				int startTime = 0;
				int room = 0;

				// assigns semester of class
				semester = cc1.Semester.Id;

                // assigns day of class or random day
                if (cc1.Days is List<Day>)
                {
                    if (cc1.Days.Count > 1)
                    {
                        var random = new Random();
                        int randomIndex = random.Next(cc1.Days.Count);
                        var randomDay = cc1.Days[randomIndex];
                        day = randomDay.Id;
                    }
                    else
                    {
                        if (cc1.Days.Count > 0)
                        {
                            foreach (var dayObj in cc1.Days)
                            {
                                day = dayObj.Id;
                            }
                        }
                        else
                        {
                            Day randomDay = this.Configuration.AddRandomDay();
                            day = randomDay.Id;
                        }
                    }
                }

                // assigns startTime of class or random startTime
                if (cc1.StartTimes is List<StartTime>)
                {
                    if (cc1.StartTimes.Count > 1)
                    {
                        var random = new Random();
                        int randomIndex = random.Next(cc1.StartTimes.Count);
                        var randomStartTime = cc1.StartTimes[randomIndex];
                        startTime = randomStartTime.Id;
                    }
                    else
                    {
                        if (cc1.StartTimes.Count > 0)
                        {
                            foreach (var startTimeObj in cc1.StartTimes)
                            {
                                startTime = startTimeObj.Id;
                            }
                        }
                        else
                        {
                            StartTime randomStartTime = this.Configuration.AddRandomStartTime(dur);
                            startTime = randomStartTime.Id;
                        }
                    }
                }

                // assigns room of class or random room
                if (cc1.Rooms is List<Room>)
                {
                    if (cc1.Rooms.Count > 1)
                    {
                        var random = new Random();
                        int randomIndex = random.Next(cc1.Rooms.Count);
                        var randomRoom = cc1.Rooms[randomIndex];
                        room = randomRoom.Id;
                        cc1.FinalRooms = randomRoom;
                    }
                    else
                    {
                        if (cc1.Rooms.Count > 0)
                        {
                            foreach (var roomObj in cc1.Rooms)
                            {
                                room = roomObj.Id;
                                cc1.FinalRooms = roomObj;
                            }
                        }
                        else
                        {
                            if (!cc1.LabRequired)
                            {
                                Room randomRoom = this.Configuration.AddRandomRoomTheory(semester);
                                room = randomRoom.Id;
                                cc1.FinalRooms = randomRoom;
                            }
                            else
                            {
                                Room randomRoom = this.Configuration.AddRandomRoomLab();
                                room = randomRoom.Id;
                                cc1.FinalRooms = randomRoom;
                            }
                        }
                    }
                }


                reservation2 = Reservation.GetReservation(nsemester, day, startTime, semester);
			}

			for (int j = dur - 1; j >= 0; --j)
			{
				// move class hour to new time-space slot
				Slots[reservation2.GetHashCode() + j].Add(cc1);
			}

			// change entry of class table to point to new time-space slots
			Classes[cc1] = reservation2.GetHashCode();
		}

		// Performs mutation on chromosome
		public void Mutation(int mutationSize, float mutationProbability)
		{
			// check probability of mutation operation
			if (Configuration.Rand() % 100 > mutationProbability)
				return;

			// number of classes
			var numberOfClasses = Classes.Count;

			// move selected number of classes at random position
			for (int i = mutationSize; i > 0; --i)
			{
				// select random chromosome for movement
				int mpos = Configuration.Rand() % numberOfClasses;

				// current time-space slot used by class
				var cc1 = Classes.Keys.ElementAt(mpos);
				Repair(cc1, Classes[cc1], null);
			}

			CalculateFitness();
		}

		// Calculates fitness value of chromosome
		public void CalculateFitness()
		{
            //SQLiteConnection con = Database.GetConnection();

            // increment value when criteria violation occurs
            Objectives = new double[Model.Criteria.Weights.Length];
		
			// chromosome's score
			float score = 0;

			int numberOfSemesters = Configuration.NumberOfSemesters;
			int daySize = Constant.DAY_HOURS * numberOfSemesters;

			int ci = 0;
			// check criterias and calculate scores for each class in schedule
			foreach (var cc in Classes.Keys)
			{
				// coordinate of time-space slot
				var reservation = Reservation.GetReservation(Classes[cc]);
				int day = reservation.Day;
				int time = reservation.Time;
				int semester = reservation.Semester;

				//cc.FinalDays = Configuration.GetDayById(day);
				//cc.FinalStartTimes = Configuration.GetStartTimeById(time);


                int dur = cc.Duration;

				// check for classes overlapping in the same semester
				var ro = Model.Criteria.IsSemesterOverlapped(Slots, reservation, dur);

				// on semester overlapping
				Criteria[ci + 0] = !ro;


                // check for classes overlapping of the same professor/room
                int timeId = day * daySize + time;
				var total_overlap = Model.Criteria.IsOverlappedProfAndRoom(Slots, cc, numberOfSemesters, timeId);

				// professors have no overlapping classes
				Criteria[ci + 1] = !total_overlap[0];

				// rooms have no overlapping classes
				Criteria[ci + 2] = !total_overlap[1];

				// Check overlapping of classes for professors with meetings
				bool to = Model.Criteria.IsOverlappedMeetingProf(Slots, cc, day, time);

				// On typeofProf overlapping
				Criteria[ci + 3] = !to;

				// Check if there's at least one free hour from 12-16 for every day
				bool fh = Model.Criteria.IsAtLeastOneFreeHour(Slots, numberOfSemesters);

				// On AtLeastOneFreeHour overlapping
				Criteria[ci + 4] = !fh;

				// Check if there's at least one class every day
				bool leastOneClass = Model.Criteria.IsAtLeastOneClass(Slots, numberOfSemesters);

				// On AtLeastOneClass overlapping
				Criteria[ci + 5] = !leastOneClass;

				int dayId = day * daySize;
				// Check if the dependencies are on the same or different day
				if (cc.HowManyDays == 1 || cc.HowManyDays == 5)
				{
					bool dpSameOrDiff = Model.Criteria.IsDependencySameOrDifferentDay(Slots, cc, numberOfSemesters, dayId, daySize);
					// On isDependencySameOrDifferentDay overlapping
					Criteria[ci + 6] = !dpSameOrDiff;
				}
				else
				{
					Criteria[ci + 6] = true;
				}

				// Check if the dependencies are in how many days
				if (cc.HowManyDays >= 2 && cc.HowManyDays <= 4)
				{
					bool dpHowManyDays = Model.Criteria.IsDependencyInHowManyDays(Slots, cc, numberOfSemesters, day);
					// On isDependencyInHowManyDays overlapping
					Criteria[ci + 7] = !dpHowManyDays;
				}
				else
				{
					Criteria[ci + 7] = true;
				}

				for (int i = 0; i < Objectives.Length; ++i) {
					if (Criteria[ci + i])
						++score;
					else
					{
						score += Model.Criteria.Weights[i];
						Objectives[i] += Model.Criteria.Weights[i] > 0 ? 1 : 2;
					}
				}
				ci += Model.Criteria.Weights.Length;
			}

			// calculate fitess value based on score
			Fitness = score / Criteria.Length;
		}

		// Returns fitness value of chromosome
		public float Fitness { get; private set; }

		public Configuration Configuration { get; private set; }

		// Returns reference to table of classes
		public SortedDictionary<CourseClass, int> Classes { get; private set; }

		// Returns array of flags of class requirements satisfaction
		public bool[] Criteria { get; private set; }

		// Return reference to array of time-space slots
		public List<CourseClass>[] Slots { get; private set; }
		
		public double[] Objectives { get; private set; }

    }
}
