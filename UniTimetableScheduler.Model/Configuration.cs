using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;


namespace Scheduler.Model
{
	public class Configuration
    {
        // Parsed professors
        private readonly Dictionary<int, Professor> _professors;

        // Parsed courses
        private readonly Dictionary<int, Course> _courses;

        // Parsed rooms
        private readonly Dictionary<int, Room> _rooms;

        // Parsed semesters
        private readonly Dictionary<int, Semester> _semesters;

        // Parsed days
        private readonly Dictionary<int, Day> _days;

        // Parsed startTimes
        private readonly Dictionary<int, StartTime> _startTimes;

        // Parsed dependencies
        //private readonly Dictionary<int, Dependency> _dependencies;

        // Generate a random number  
        private static Random _random = new(DateTime.Now.Millisecond);

        // Initialize data
        public Configuration()
        {
            Empty = true;
            _professors = new();
            _courses = new();
            _rooms = new();
            _semesters = new();
            _days = new();
            _startTimes = new();
            //_dependencies = new();
            CourseClasses = new();
        }

        // Returns professor with specified ID
        // If there is no professor with such ID method returns NULL
        Professor GetProfessorById(int id)
        {
            if (!_professors.ContainsKey(id))
                return null;
            return _professors[id];
        }

        // Returns number of parsed professors
        public int NumberOfProfessors => _professors.Count;
        

        // Returns course with specified ID
        // If there is no course with such ID method returns NULL
        Course GetCourseById(int id)
        {
            if (!_courses.ContainsKey(id))
                return null;
            return _courses[id];
        }

        public int NumberOfCourses => _courses.Count;

        // Returns room with specified ID
        // If there is no room with such ID method returns NULL
        public Room GetRoomById(int id)
        {
            if (!_rooms.ContainsKey(id))
                return null;
            return _rooms[id];
        }

        // Returns number of parsed rooms
        public int NumberOfRooms => _rooms.Count;

        // Returns random Room for Theory Courses
        public Room AddRandomRoomTheory(int semester)
        {
            int[] randomRoomIds = { 1, 2, 3 };
            string[] randomRoomNames = { "AMF", "A1", "A2" };

            int id;
            string name;

            if (semester == 0 || semester == 1)
            {
                // Adjust probabilities to favor room with id 1
                int[] roomWeights = { 3, 1, 1 };  // Higher weight for room with id 1 ("AMF")

                // Use a random number generator to select a room based on weights
                Random random = new Random();
                int selectedIndex = SelectRoomBasedOnWeights(roomWeights, random);

                id = randomRoomIds[selectedIndex];
                name = randomRoomNames[selectedIndex];
            }
            else
            {
                // Equal probabilities for all rooms for other semesters
                Random random = new Random();
                int selectedIndex = random.Next(randomRoomIds.Length);

                id = randomRoomIds[selectedIndex];
                name = randomRoomNames[selectedIndex];
            }

            bool lab = false;

            return new Room(id, name, lab);
        }

        // Helper method to select an item based on weights
        private int SelectRoomBasedOnWeights(int[] weights, Random random)
        {
            int totalWeight = weights.Sum();
            int randomValue = random.Next(totalWeight);

            for (int i = 0; i < weights.Length; i++)
            {
                randomValue -= weights[i];
                if (randomValue < 0)
                {
                    return i;
                }
            }

            return weights.Length - 1;  // Default to the last item
        }

        // Returns random Room for Lab Courses
        public Room AddRandomRoomLab()
        {
            int[] randomRoomIds = { 4, 5, 6, 7, 8, 9, 10 };
            string[] randomRoomNames = { "WI", "WII", "ECS", "EHK", "EPYS", "THL", "ROMP" };

            // Use a random number generator to select a room
            Random random = new Random();
            int randomIndex = random.Next(randomRoomIds.Length);

            int id = randomRoomIds[randomIndex];
            string name = randomRoomNames[randomIndex];
            bool lab = true;

            return new Room(id, name, lab);
        }

        // Returns semester with specified ID
        // If there is no semester with such ID method returns NULL
        public Semester GetSemesterById(int id)
        {
            if (!_semesters.ContainsKey(id))
                return null;
            return _semesters[id];
        }

        // Returns number of parsed semesters
        public int NumberOfSemesters => _semesters.Count;

        // Returns day with specified ID
        // If there is no day with such ID method returns NULL
        public Day GetDayById(int id)
        {
            if (!_days.ContainsKey(id))
                return null;
            return _days[id];
        }

        // Returns number of parsed days
        public int NumberOfDays => _days.Count;

        // Returns a random Day
        public Day AddRandomDay()
        {
            int[] randomDayIds = { 0, 1, 2, 3, 4 };
            string[] randomDayNames = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            Random random = new Random();
            int randomValue = random.Next(randomDayIds.Length);

            int randomId = randomDayIds[randomValue];
            string randomName = randomDayNames[randomValue];

            int id = randomId;
            string name = randomName;

            return new Day(id, name);
        }

        // Returns startTimes with specified ID
        // If there is no startTimes with such ID method returns NULL
        public StartTime GetStartTimeById(int id)
        {
            if (!_startTimes.ContainsKey(id))
                return null;
            return _startTimes[id];
        }

        // Returns number of parsed startTimes
        public int NumberOfStartTimes => _startTimes.Count;

        // Returns random startTime
        public StartTime AddRandomStartTime(int dur)
        {
            int[] randomStartTimeIds = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            string[] randomStartTimeNames = { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" };

            int id = 0;
            int endId = id + dur;

            // Check if the class won't start one day and end on the next
            while (true)
            {
                Random random = new Random();
                int randomValue = random.Next(randomStartTimeIds.Length);
                int randomId = randomStartTimeIds[randomValue];
                string randomName = randomStartTimeNames[randomValue];
                id = randomId;
                endId = id + dur;

                if (endId > 14)
                {
                    continue;
                }
                else
                {
                    id = randomId;
                    string name = randomName;
                    return new StartTime(id, name);
                }
            }
        }


        // Returns dependencies with specified ID
        // If there is no dependencies with such ID method returns NULL
        //Course GetDependencyById(int id)
        //{
        //    if (!_courses.ContainsKey(id))
        //        return null;
        //    return _courses[id];
        //}

        // Returns number of parsed dependencies
        //public int NumberOfDependencies => _courses.Count;

        // Returns reference to list of parsed classes
        public List<CourseClass> CourseClasses { get; }

        // Returns number of parsed classes
        public int NumberOfCourseClasses => CourseClasses.Count;

        // Returns TRUE if configuration is not parsed yet
        public bool Empty { get; private set; }

        private static void GetMember<T>(Dictionary<string, object> data, string columnName, ref T value)
        {
            if (data.ContainsKey(columnName))
            {
                object columnValue = data[columnName];

                // Handle DBNull
                if (columnValue == DBNull.Value)
                {
                    value = default(T);
                    return;
                }

                // Handle conversions based on TypeCode
                switch (Type.GetTypeCode(typeof(T)))
                {
                    case TypeCode.Int32:
                        value = (T)Convert.ChangeType(columnValue, typeof(int));
                        break;
                    case TypeCode.Double:
                        value = (T)Convert.ChangeType(columnValue, typeof(double));
                        break;
                    case TypeCode.Boolean:
                        value = (T)Convert.ChangeType(columnValue, typeof(bool));
                        break;
                    case TypeCode.String:
                        value = (T)Convert.ChangeType(columnValue, typeof(string));
                        break;
                    // Add more cases for other types if needed
                    default:
                        value = default(T);
                        break;
                }
            }
        }

        // Reads course's data from database, makes object and returns
        // Returns NULL if method cannot parse configuration data
        private Course ParseCourse(Dictionary<string, object> data)
        {
            if (!data.ContainsKey("CourseID"))
                return null;
            long courseIdAsLong = (long)data["CourseID"];
            int id = Convert.ToInt32(courseIdAsLong);

            if (!data.ContainsKey("Name"))
                return null;
            string name = (string)data["Name"];

            return new Course(id, name);
        }

        // Reads professor's data from database, makes object and returns
        // Returns NULL if method cannot parse configuration data
        private Professor ParseProfessor(Dictionary<string, object> data)
        {
            if (!data.ContainsKey("ProfessorID"))
                return null;
            long professorIdAsLong = (long)data["ProfessorID"];
            int id = Convert.ToInt32(professorIdAsLong);

            if (!data.ContainsKey("Name"))
                return null;
            string name = (string)data["Name"];

            if (!data.ContainsKey("Meeting"))
                return null;
            bool meeting = (bool)data["Meeting"];

            return new Professor(id, name, meeting);
        }

        // Reads semester's data from database, makes object and returns
        // Returns NULL if method cannot parse configuration data
        private Semester ParseSemester(Dictionary<string, object> data)
        {
            if (!data.ContainsKey("SemesterID"))
                return null;
            long semesterIdAsLong = (long)data["SemesterID"];
            int id = Convert.ToInt32(semesterIdAsLong);

            if (!data.ContainsKey("Name"))
                return null;
            string name = (string)data["Name"];

            return new Semester(id, name);
        }

        // Reads day's data from database, makes object and returns
        // Returns NULL if method cannot parse configuration data
        private Day ParseDay(Dictionary<string, object> data)
        {
            if (!data.ContainsKey("DayID"))
                return null;
            long dayIdAsLong = (long)data["DayID"];
            int id = Convert.ToInt32(dayIdAsLong);

            if (!data.ContainsKey("Name"))
                return null;
            string name = (string)data["Name"];

            return new Day(id, name);
        }

        // Reads startTime's data from database, makes object and returns
        // Returns NULL if method cannot parse configuration data
        private StartTime ParseStartTime(Dictionary<string, object> data)
        {
            if (!data.ContainsKey("StartTimeID"))
                return null;
            long startTimeIdAsLong = (long)data["StartTimeID"];
            int id = Convert.ToInt32(startTimeIdAsLong);

            if (!data.ContainsKey("Name"))
                return null;
            string name = (string)data["Name"];

            return new StartTime(id, name);
        }

        // Reads rooms's data from database, makes object and returns
        // Returns NULL if method cannot parse configuration data
        private Room ParseRoom(Dictionary<string, object> data)
        {
            if (!data.ContainsKey("RoomID"))
                return null;
            long roomIdAsLong = (long)data["RoomID"];
            int id = Convert.ToInt32(roomIdAsLong);

            if (!data.ContainsKey("Name"))
                return null;
            string name = (string)data["Name"];

            bool lab = false;
            if (data.ContainsKey("Lab"))
                lab = (bool)data["Lab"];

            return new Room(id, name, lab);
        }

        //Reads dependency's data from database, makes object and returns
        // Returns NULL if method cannot parse configuration data
        //private Dependency ParseDependency(Dictionary<string, object> data)
        //{
        //    if (!data.ContainsKey("DependencyID"))
        //        return null;
        //    long id = 0;
        //    if (data["DependencyID"] is long)
        //    {
        //        id = (long)data["DependencyID"];
        //    }
        //    else if (data["DependencyID"] is int)
        //    {
        //        id = (int)data["DependencyID"];
        //    }

        //    if (!data.ContainsKey("Name"))
        //        return null;
        //    string name = (string)data["Name"];

        //    bool lab = false;
        //    if (data.ContainsKey("lab"))
        //        lab = (bool)data["lab"];

        //    return new Dependency(id, name, lab);
        //}


        // Reads class' data from database, makes object and returns pointer
        // Returns NULL if method cannot parse configuration data
        private CourseClass ParseCourseClass(SQLiteConnection con, Dictionary<string, object> data)
        {
            int id = 1;
            int pid = 0;
            int cid = 0;
            int dur = 1;
            int semesters = 0;
            bool lab = false;


            var room_list = new List<Room>();
            var day_list = new List<Day>();
            var startTime_list = new List<StartTime>();
            //var room_list = new List<int>();
            //var day_list = new List<int>();
            //var startTime_list = new List<int>();

            var finalRoom_list = new List<Room>();
            var finalDay_list = new List<Day>();
            var finalStartTime_list = new List<StartTime>();
            var finalRooms = 0;
            var finalDays = 0;
            var finalStartTimes = 0;
            var dependency_list = new List<int>();
            int inHowManyDays = 0;

            foreach (string key in data.Keys)
            {
                switch (key)
                {
                    // Existing cases...
                    case "SchedulerID":
                        GetMember(data, key, ref id);

                        var days = GetDayListFromScheduler(con, id);
                        foreach (var day in days)
                        {
                            var d = GetDayById(day);
                            if (d != null)
                                day_list.Add(d);
                        }
                        var startTimes = GetStartTimeListFromScheduler(con, id);
                        foreach (var startTime in startTimes)
                        {
                            var st = GetStartTimeById(startTime);
                            if (st != null)
                                startTime_list.Add(st);
                        }
                        var rooms = GetRoomListFromScheduler(con, id);
                        foreach (var room in rooms)
                        {
                            var r = GetRoomById(room);
                            if (r != null)
                                room_list.Add(r);
                        }

                        var result = GetDependencyFromScheduler(con, id);
                        List<int> dependencies = result.DependencyList;
                        foreach (var dependency in dependencies)
                        {
                            dependency_list.Add(dependency);
                        }
                        inHowManyDays = result.InHowManyDays;
                        break;
                    case "Course":
                        GetMember(data, key, ref cid);

                        lab = GetLabFromCourse(con, cid);

                        break;
                    case "Professor":
                        GetMember(data, key, ref pid);
                        break;
                    case "Duration":
                        GetMember(data, key, ref dur);
                        break;
                    case "Semester":
                        GetMember(data, key, ref semesters);
                        break;
                    case "FinalRoom":
                        GetMember(data, key, ref finalRooms);
                        break;
                    case "FinalDay":
                        GetMember(data, key, ref finalDays);
                        break;
                    case "FinalStartTime":
                        GetMember(data, key, ref finalStartTimes);
                        break;
                        

                }
            }

            // get professor, course, semester to which this class belongs
            Professor prof = GetProfessorById(pid);
            Course course = GetCourseById(cid);
            Semester semester = GetSemesterById(semesters);
            Day finalDay = GetDayById(finalDays);
            StartTime finalStartTime = GetStartTimeById(finalStartTimes);
            Room finalRoom = GetRoomById(finalRooms);

            // if course and prof doesnt exist then return null
            if (course == null || prof == null)
                return null;



            // make object and return
            return new CourseClass(id, prof, course, lab, dur, semester, room_list.ToArray(), day_list.ToArray(), startTime_list.ToArray(), finalDay, finalStartTime, finalRoom, dependency_list.ToArray(), inHowManyDays);
        }

        public List<int> GetDayListFromScheduler(SQLiteConnection con, int schedulerId)
        {
            List<int> dayList = new List<int>();

            using (var cmd = new SQLiteCommand(con))
            {
                cmd.CommandText = $"SELECT DISTINCT DayID FROM DayList WHERE SchedulerID = {schedulerId}";
                //cmd.Parameters.AddWithValue("@schedulerId", schedulerId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int attributeValue = reader.GetInt32(0); // Assuming the attribute is in the first column
                        dayList.Add(attributeValue);
                    }
                }
            }

            return dayList;
        }
        public List<int> GetStartTimeListFromScheduler(SQLiteConnection con, int schedulerId)
        {
            List<int> startTimeList = new List<int>();

            using (var cmd = new SQLiteCommand(con))
            {
                cmd.CommandText = $"SELECT DISTINCT StartTimeID FROM StartTimeList WHERE SchedulerID = {schedulerId}";
                //cmd.Parameters.AddWithValue("@schedulerId", schedulerId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int attributeValue = reader.GetInt32(0); // Assuming the attribute is in the first column
                        startTimeList.Add(attributeValue);
                    }
                }
            }

            return startTimeList;
        }
        public List<int> GetRoomListFromScheduler(SQLiteConnection con, int schedulerId)
        {
            List<int> roomList = new List<int>();

            using (var cmd = new SQLiteCommand(con))
            {
                cmd.CommandText = $"SELECT DISTINCT RoomID FROM RoomList WHERE SchedulerID = {schedulerId}";
                //cmd.Parameters.AddWithValue("@schedulerId", schedulerId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int attributeValue = reader.GetInt32(0); // Assuming the attribute is in the first column
                        roomList.Add(attributeValue);
                    }
                }
            }

            return roomList;
        }

        public bool GetLabFromCourse(SQLiteConnection con, int courseId)
        {
            bool lab = false;

            using (var cmd = new SQLiteCommand(con))
            {
                cmd.CommandText = $"SELECT DISTINCT Lab FROM Course WHERE CourseID = {courseId}";
                //cmd.Parameters.AddWithValue("@schedulerId", schedulerId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bool attributeValue = reader.GetBoolean(0); // Assuming the attribute is in the first column
                        lab = attributeValue;
                    }
                }
            }

            return lab;
        }

        public (List<int> DependencyList, int InHowManyDays) GetDependencyFromScheduler(SQLiteConnection con, int shedulerId)
        {
            List<int> dependencyList = new List<int>();
            int inHowManyDays = 0;

            using (var cmd = new SQLiteCommand(con))
            {
                cmd.CommandText = $"SELECT DISTINCT DependentCourseID, InHowManyDays FROM Dependency WHERE Dependency.CourseID = {shedulerId}";
                //cmd.Parameters.AddWithValue("@schedulerId", schedulerId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int dependencyValue = reader.GetInt32(0); // Assuming the attribute is in the first column
                        dependencyList.Add(dependencyValue);

                        int inHowManyDaysValue = reader.GetInt32(1); // Assuming the attribute is in the first column
                        inHowManyDays = inHowManyDaysValue;
                    }
                }
            }

            return (dependencyList, inHowManyDays);
        }


        // Parse database and store parsed object
        public void ParseDatabase(SQLiteConnection con)
        {
            // clear previously parsed objects
            _professors.Clear();
            _courses.Clear();
            _rooms.Clear();
            _semesters.Clear();
            _days.Clear();
            _startTimes.Clear();
            //_dependencies.Clear();
            CourseClasses.Clear();

            //CourseClass.RestartIDs();


            // Fetch data from SQLite tables
            var courseData = FetchDataFromTable(con, "Course");
            var professorData = FetchDataFromTable(con, "Professor");
            var semesterData = FetchDataFromTable(con, "Semester");
            var dayData = FetchDataFromTable(con, "Day");
            var startTimeData = FetchDataFromTable(con, "StartTime");
            var roomData = FetchDataFromTable(con, "Room");
            //var dependencyData = FetchDataFromTable(con, "Dependency");
            var classData = FetchDataFromTable(con, "Scheduler");


            // Parse and store data
            foreach (var data in courseData)
            {
                //var courseId = Convert.ToInt32(data["CourseID"]);
                var course = ParseCourse(data);
                _courses.Add(course.Id, course);
            }
            foreach (var data in professorData)
            {
                //var profId = Convert.ToInt32(data["ProfessorID"]);
                var prof = ParseProfessor(data);
                _professors.Add(prof.Id, prof);
            }
            foreach (var data in semesterData)
            {
                //var semesterId = Convert.ToInt32(data["SemesterID"]);
                var semester = ParseSemester(data);
                _semesters.Add(semester.Id, semester);
            }
            foreach (var data in dayData)
            {
                //var dayId = Convert.ToInt32(data["DayID"]);
                var day = ParseDay(data);
                _days.Add(day.Id, day);
            }
            foreach (var data in startTimeData)
            {
                //var startTimeId = Convert.ToInt32(data["StartTimeID"]);
                var startTime = ParseStartTime(data);
                _startTimes.Add(startTime.Id, startTime);
            }
            foreach (var data in roomData)
            {
                //var roomId = Convert.ToInt32(data["RoomID"]);
                var room = ParseRoom(data);
                _rooms.Add(room.Id, room);
            }
            //foreach (var data in dependencyData)
            //{
            //    var dependency = ParseDependency(data);
            //    _rooms.Add(dependency.Id, dependency);
            //}
            foreach (var data in classData)
            {
                var courseClass = ParseCourseClass(con, data);
                CourseClasses.Add(courseClass);
            }

            Empty = false;
        }

        // Helper method to fetch data from SQLite table
        private List<Dictionary<string, object>> FetchDataFromTable(SQLiteConnection con, string tableName)
        {
            var data = new List<Dictionary<string, object>>();

            using (var command = new SQLiteCommand($"SELECT * FROM {tableName}", con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var rowData = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            object columnValue = reader.GetValue(i);

                            Console.WriteLine($"Column: {columnName}, Type: {columnValue.GetType()}, Value: {columnValue}");

                            rowData.Add(reader.GetName(i), reader.GetValue(i));
                        }
                        data.Add(rowData);
                    }
                }
            }

            return data;
        }

        public static int Rand()
        {
            return _random.Next(0, 32767);
        }
        //public static double Random()
        //{
        //    return _random.NextDouble();
        //}

        //public static int Rand(int size)
        //{
        //    return _random.Next(size);
        //}

        //public static int Rand(int min, int max)
        //{
        //    return min + Rand(max - min + 1);
        //}

        //public static double Rand(double min, double max)
        //{
        //    return min + _random.NextDouble() * (max - min);
        //}

        //public static double NextGaussian()
        //{
        //    var u1 = 1.0 - _random.NextDouble(); //uniform(0,1] random doubles
        //    var u2 = 1.0 - _random.NextDouble();
        //    return Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
        //}

        public static void Seed()
        {
            _random = new Random(DateTime.Now.Millisecond);
        }

    }
}
