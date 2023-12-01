using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Scheduler.Model
{
    public class CourseClass : IComparable<CourseClass>
    {
        private static int _nextClassId = 0;
        // Initializes class object
        public CourseClass(int schedulerId, Professor professor, Course course, bool requiresLab, int duration, Semester semester, Room[] room, Day[] day, StartTime[] startTime, Day finalDay, StartTime finalStartTime, Room finalRoom, int[] dependency, int howManyDays )
        {
            //Id = _nextClassId++;
            SchedulerId = schedulerId;
            Professor = professor;
			Course = course;
			//NumberOfSeats = 0;
			LabRequired = requiresLab;
			Duration = duration;
			Semester = semester;
			Rooms = new List<Room>();
            Days = new List<Day>();
            StartTimes = new List<StartTime>();
            FinalDays = finalDay;
            FinalStartTimes = finalStartTime;
            FinalRooms = finalRoom;
            Dependencies = new List<int>();
            HowManyDays = howManyDays;

            // bind professor to class
            Professor.AddCourseClass(this);
            // bind semester to class
            Semester.AddCourseClass(this);

            // bind student groups to class
   //         foreach (StudentsGroup group in groups)
   //         {
			//	group.AddClass(this);
			//	Groups.Add(group);
			//	NumberOfSeats += group.NumberOfStudents;
			//}

            // bind rooms to class
            foreach (Room r in room)
            {
                r.AddCourseClass(this);
				Rooms.Add(r);
            }
            // bind days to class
            foreach (Day d in day)
            {
                d.AddCourseClass(this);
                Days.Add(d);
            }
            // bind startTimes to class
            foreach (StartTime st in startTime)
            {
                st.AddCourseClass(this);
                StartTimes.Add(st);
            }
            // bind finalDays to class
            //foreach (Day d in finalDay)
            //{
            //    d.AddCourseClass(this);
            //    FinalDays.Add(d);
            //}
            // bind finalStartTimes to class
            //foreach (StartTime st in finalStartTime)
            //{
            //    st.AddCourseClass(this);
            //    FinalStartTimes.Add(st);
            //}
            // bind finalRooms to class
            //foreach (Room r in finalRoom)
            //{
            //    r.AddCourseClass(this);
            //    FinalRooms.Add(r);
            //}
            // bind dependencies to class
            foreach (int dp in dependency)
            {
                Dependencies.Add(dp);
            }
        }

		// Returns TRUE if another class has one or overlapping student groups.
		//public bool GroupsOverlap(CourseClass c)
  //      {
		//	return Groups.Intersect(c.Groups).Any();
  //      }
        // Returns TRUE if another class has same semester.
        public bool SemesterOverlaps(CourseClass c)
        {
            return Semester.Equals(c.Semester);
        }
        // Returns TRUE if another class has same professor.
        public bool ProfessorOverlaps(CourseClass c) {
			return Professor.Equals(c.Professor);
		}
        // Returns TRUE if another class has same room.
        public bool RoomOverlaps(CourseClass c)
        {
            return FinalRooms.Equals(c.FinalRooms);
        }

        public int CompareTo(CourseClass other)
		{
            if (other == null)
                return -1;
            return other.SchedulerId - SchedulerId;
        }

        // Returns class ID - automatically assigned
        //public int Id { get; set; }

        // Returns class ID
        public int SchedulerId { get; set; }

        // Return pointer to professor who teaches
        public Professor Professor { get; set; }

		// Return pointer to course to which class belongs
		public Course Course { get; set; }

		// Returns reference to list of student groups who attend class
		//public List<StudentsGroup> Groups { get; set; }

		// Returns number of seats (students) required in room
		public int NumberOfSeats { get; set; }

		// Returns TRUE if class requires computers in room
		public bool LabRequired { get; set; }

		// Returns duration of class in hours
		public int Duration { get; set; }

        // Returns semester of class in hours
        public Semester Semester { get; set; }

        // Returns reference to list of rooms
        public List<Room> Rooms { get; set; }

        // Returns reference to list of days
        public List<Day> Days { get; set; }

        // Returns reference to list of startTimes
        public List<StartTime> StartTimes { get; set; }

        // Returns reference to list of finalDays
        public Day FinalDays { get; set; }

        // Returns reference to list of finalStartTimes
        public StartTime FinalStartTimes { get; set; }

        // Returns reference to list of finalRooms
        public Room FinalRooms { get; set; }

        // Returns reference to list of dependencies
        public List<int> Dependencies { get; set; }

        // Returns in howManyDays the classes should be
        public int HowManyDays { get; set; }

        // Restarts ID assigments
        //public static void RestartIDs() { _nextClassId = 0; }
    }
}
