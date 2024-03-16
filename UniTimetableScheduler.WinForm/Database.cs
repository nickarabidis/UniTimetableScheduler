using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.WinForm
{
    public class Database
    {
        private static bool check = true;
        private static SQLiteConnection con;
        private static SQLiteCommand sqlite_cmd;


        /*
         we create the connection of the db
        and it returns sqliteconnection we need for the other functions
         
         */


        //____________________________________SETUP____________________________________________

        public static void CreateDb()
        {
            if (check)
            {

                //con = new SQLiteConnection($"Data Source = {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/db/database.accdb; Version = 3; New = True; Compress = True; ");
                con = new SQLiteConnection($"Data Source = {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/db/database.db; Version = 3; New = True; Compress = True; ");
                con.Open();
                check = false;
            }
        }

        /*
         
            Get database connection
         
         */
        public static SQLiteConnection GetConnection()
        {
            return con;
        }

        /*
         
         We create and set up the db tables 
          the parammeter is to get the connection
         
         */


        /// <summary>
        /// INSERTS IN TABLE
        /// </summary>

        public static void CreateTableCourse()
        {
            sqlite_cmd = con.CreateCommand();

            //Table for Course
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Course(" +
                "CourseID INTEGER(4) PRIMARY KEY," +
                "Name VARCHAR(150) NOT NULL," +
                "Lab BOOL NOT NULL)";
            sqlite_cmd.ExecuteNonQuery();
        }
        public static void CreateTableProfessor()
        {
            sqlite_cmd = con.CreateCommand();

            //Table for Professor
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Professor(" +
                "ProfessorID INTEGER(4) PRIMARY KEY," +
                "Name VARCHAR(150) NOT NULL," +
                "Meeting BOOL NOT NULL)";
            sqlite_cmd.ExecuteNonQuery();
        }
        public static void CreateTableSemester()
        {
            sqlite_cmd = con.CreateCommand();

            //Table for Semester
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Semester(" +
                "SemesterID INTEGER(4) PRIMARY KEY," +
                "Name VARCHAR(150) NOT NULL)";
            sqlite_cmd.ExecuteNonQuery();
        }
        public static void CreateTableDay()
        {
            sqlite_cmd = con.CreateCommand();

            //Table for Day
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Day(" +
                "DayID INTEGER(4) PRIMARY KEY," +
                "Name VARCHAR(150) NOT NULL)";
            sqlite_cmd.ExecuteNonQuery();
        }
        public static void CreateTableStartTime()
        {
            sqlite_cmd = con.CreateCommand();

            //Table for StartTime
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS StartTime(" +
                "StartTimeID INTEGER(4) PRIMARY KEY," +
                "Name VARCHAR(150) NOT NULL)";
            sqlite_cmd.ExecuteNonQuery();
        }
        public static void CreateTableRoom()
        {
            sqlite_cmd = con.CreateCommand();

            //Table for Room
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Room(" +
                "RoomID INTEGER(4) PRIMARY KEY," +
                "Name VARCHAR(150) NOT NULL," +
                "Lab BOOL NOT NULL)";
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void CreateTableScheduler()
        {
            sqlite_cmd = con.CreateCommand();

            //Table for Scheduler
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Scheduler(" +
                "SchedulerID INTEGER(4) PRIMARY KEY," +
                "Course INTEGER(4) NOT NULL," +
                "Professor INTEGER(4) NOT NULL," +
                "Lab BOOL NULL," +
                "Duration INTEGER(4) NOT NULL," +
                "Semester INTEGER(4) NOT NULL," +
                "FinalDay INTEGER(4) NULL," +
                "FinalStartTime INTEGER(4) NULL," +
                "FinalRoom INTEGER(4) NULL," +
                "FOREIGN KEY (Course) REFERENCES Course(CourseID)," +
                "FOREIGN KEY (Professor) REFERENCES Professor(ProfessorID)," +
                "FOREIGN KEY (Semester) REFERENCES Semester(SemesterID))";
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void CreateTableDayList()
        {
            sqlite_cmd = con.CreateCommand();

            //Table for DayList
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS DayList (" +
                "SchedulerID INTEGER(4) NOT NULL," +
                "DayID INTEGER(4) NOT NULL," +
                "PRIMARY KEY(SchedulerID, DayID)," +
                "FOREIGN KEY (SchedulerID) REFERENCES Scheduler(SchedulerID)," +
                "FOREIGN KEY (DayID) REFERENCES Day(DayID))";
            sqlite_cmd.ExecuteNonQuery();

        }

        public static void CreateTableStartTimeList()
        {
            sqlite_cmd = con.CreateCommand();

            //Table for StartTimeList
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS StartTimeList (" +
                "SchedulerID INTEGER(4) NOT NULL," +
                "StartTimeID INTEGER(4) NOT NULL," +
                "PRIMARY KEY(SchedulerID, StartTimeID)," +
                "FOREIGN KEY (SchedulerID) REFERENCES Scheduler(SchedulerID)," +
                "FOREIGN KEY (StartTimeID) REFERENCES StartTime(StartTimeID))";
            sqlite_cmd.ExecuteNonQuery();

        }

        public static void CreateTableRoomList()
        {
            sqlite_cmd = con.CreateCommand();

            //Table for RoomList
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS RoomList (" +
                "SchedulerID INTEGER(4) NOT NULL," +
                "RoomID INTEGER(4) NOT NULL," +
                "PRIMARY KEY(SchedulerID, RoomID)," +
                "FOREIGN KEY (SchedulerID) REFERENCES Scheduler(SchedulerID)," +
                "FOREIGN KEY (RoomID) REFERENCES Room(RoomID))";
            sqlite_cmd.ExecuteNonQuery();

        }
        public static void CreateTableDependency()
        {
            sqlite_cmd = con.CreateCommand();

            //Table for DependencyRelateToCourse
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Dependency(" +
                "CourseID INTEGER(4) NOT NULL," +
                "DependentCourseID INTEGER(4) NOT NULL," +
                "InHowManyDays INTEGER(4)," +
                "PRIMARY KEY(CourseID, DependentCourseID)," +
                "FOREIGN KEY (CourseID) REFERENCES Scheduler(Course)," +
                "FOREIGN KEY (DependentCourseID) REFERENCES Course(CourseID))";
            sqlite_cmd.ExecuteNonQuery();
        }



        /// <summary>
        /// INSERTS IN TABLE
        /// </summary>

        public static void InsertInCourse()
        {
            sqlite_cmd = con.CreateCommand();

            sqlite_cmd.CommandText += "INSERT INTO Course (CourseID,Name,Lab) VALUES " +
                " (1, 'Discrete Math', 0), " +
                " (2, 'Introduction to C++ Theory', 0), " +
                " (3, 'Introduction to C++ Lab', 1), " +
                " (4, 'Theory of Education', 0), " +
                " (5, 'Math I', 0), " +
                " (6, 'Digital Design', 0), " +
                " (7, 'English Technical Terminology', 0), " +
                " (8, 'Object Oriented Programming', 0), " +
                " (9, 'Scientific Computing Theory', 0), " +
                " (10, 'Scientific Computing Lab', 1), " +
                " (11, 'Operating Systems', 0), " +
                " (12, 'Compilers', 0), " +
                " (13, 'Advanced Applications of Digital Design Theory', 0), " +
                " (14, 'Advanced Applications of Digital Design Lab', 1), " +
                " (15, 'Applied Mathematics', 0), " +
                " (16, 'Educational Research Methodology', 0), " +
                " (17, 'Computer Networks', 0), " +
                " (18, 'Introduction to Computational Intelligence Theory', 0), " +
                " (19, 'Introduction to Computational Intelligence Lab', 1), " +
                " (20, 'Teaching and Applications in Informatics', 0), " +
                " (21, 'Software Technology I', 0), " +
                " (22, 'Identify Patterns', 0), " +
                " (23, 'Neural Networks', 0), " +
                " (24, 'Wireless Networks and Mobile Communications', 0), " +
                " (25, 'Information Security and Privacy', 0), " +
                " (26, 'Autonomous Animated Robots and Applications', 0), " +
                " (27, 'Special Database Topics', 0), " +
                " (28, 'Introduction to Artificial Vision', 0), " +
                " (29, 'Intelligent Robots Theory', 0), " +
                " (30, 'Intelligent Robots Lab', 1), " +
                " (31, 'Programming of the World Wide Web Theory', 0), " +
                " (32, 'Programming of the World Wide Web Lab', 1), " +
                " (33, 'Parallel and Distributed Computing', 0), " +
                " (34, 'Advanced Operating Systems Topics', 0)";
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void InsertInProfessor()
        {
            sqlite_cmd = con.CreateCommand();

            sqlite_cmd.CommandText = "INSERT INTO Professor (ProfessorID, Name, Meeting) VALUES " +
                "(1, 'Teacher 1', 1), " +
                "(2, 'Teacher 2', 1), " +
                "(3, 'Teacher 3', 1), " +
                "(4, 'Teacher 4', 1), " +
                "(5, 'Teacher 5', 1), " +
                "(6, 'Teacher 6', 1), " +
                "(7, 'Teacher 7', 1), " +
                "(8, 'Teacher 8', 1), " +
                "(9, 'Teacher 9', 1), " +
                "(10, 'Teacher 10', 1), " +
                "(11, 'Teacher 11', 1), " +
                "(12, 'Teacher 12', 0), " +
                "(13, 'Teacher 13', 0), " +
                "(14, 'Sub-Teacher 1', 0), " +
                "(15, 'Sub-Teacher 2', 0), " +
                "(16, 'Sub-Teacher 3', 0), " +
                "(17, 'Sub-Teacher 4', 0), " +
                "(18, 'Sub-Teacher 5', 0), " +
                "(19, 'Sub-Teacher 6', 0), " +
                "(20, 'Sub-Teacher 7', 0), " +
                "(21, 'Sub-Teacher 8', 0), " +
                "(22, 'Sub-Teacher 9', 0)";
            sqlite_cmd.ExecuteNonQuery();
        }
        public static void InsertInSemester()
        {
            sqlite_cmd = con.CreateCommand();

            sqlite_cmd.CommandText = "INSERT INTO Semester (SemesterID, Name) VALUES " +
                "(0, '1'), " +
                "(1, '3'), " +
                "(2, '5'), " +
                "(3, '7')";
            sqlite_cmd.ExecuteNonQuery();
        }
        public static void InsertInDay()
        {
            sqlite_cmd = con.CreateCommand();

            sqlite_cmd.CommandText = "INSERT INTO Day (DayID, Name) VALUES " +
                "(0, 'Monday'), " +
                "(1, 'Tuesday'), " +
                "(2, 'Wednesday'), " +
                "(3, 'Thursday'), " +
                "(4, 'Friday')";
            sqlite_cmd.ExecuteNonQuery();
        }
        public static void InsertInStartTime()
        {
            sqlite_cmd = con.CreateCommand();

            sqlite_cmd.CommandText = "INSERT INTO StartTime (StartTimeID, Name) VALUES " +
                "(0, '8'), " +
                "(1, '9'), " +
                "(2, '10'), " +
                "(3, '11'), " +
                "(4, '12'), " +
                "(5, '13'), " +
                "(6, '14'), " +
                "(7, '15'), " +
                "(8, '16'), " +
                "(9, '17'), " +
                "(10, '18'), " +
                "(11, '19'), " +
                "(12, '20'), " +
                "(13, '21')";
            sqlite_cmd.ExecuteNonQuery();
        }
        public static void InsertInRoom()
        {
            sqlite_cmd = con.CreateCommand();

            sqlite_cmd.CommandText = "INSERT INTO Room (RoomID, Name, Lab) VALUES " +
                "(1, 'AMF', 0), " +
                "(2, 'A1', 0), " +
                "(3, 'A2', 0), " +
                "(4, 'WI', 1), " +
                "(5, 'WII', 1), " +
                "(6, 'ECS', 1), " +
                "(7, 'EHK', 1), " +
                "(8, 'EPYS', 1), " +
                "(9, 'THL', 1), " +
                "(10, 'ROMP', 1)";
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void InsertInScheduler()
        {
            sqlite_cmd = con.CreateCommand();

            sqlite_cmd.CommandText = "INSERT INTO Scheduler (SchedulerID, Course, Professor, Duration, Semester) VALUES " +
                "(1, 1, 5, 4, 0), " +
                "(2, 2, 2, 3, 0), " +
                "(3, 3, 6, 6, 0), " +
                "(4, 3, 6, 6, 0), " +
                "(5, 3, 14, 4, 0), " +
                "(6, 4, 9, 2, 0), " +
                "(7, 4, 9, 4, 0), " +
                "(8, 5, 2, 4, 0), " +
                "(9, 6, 12, 4, 0), " +
                "(10, 7, 15, 2, 0), " +
                "(11, 8, 3, 3, 1), " +
                "(12, 9, 2, 2, 1), " +
                "(13, 10, 13, 4, 1), " +
                "(14, 10, 13, 5, 1), " +
                "(15, 11, 4, 4, 1), " +
                "(16, 12, 4, 3, 1), " +
                "(17, 13, 12, 2, 1), " +
                "(18, 14, 12, 8, 1), " +
                "(19, 15, 16, 3, 1), " +
                "(20, 16, 17, 3, 1), " +
                "(21, 17, 7, 3, 2), " +
                "(22, 18, 1, 3, 2), " +
                "(23, 19, 18, 4, 2), " +
                "(24, 19, 18, 4, 2), " +
                "(25, 20, 8, 4, 2), " +
                "(26, 21, 10, 3, 2), " +
                "(27, 22, 19, 3, 2), " +
                "(28, 23, 20, 3, 2), " +
                "(29, 24, 5, 3, 3), " +
                "(30, 25, 7, 3, 3), " +
                "(31, 26, 10, 3, 3), " +
                "(32, 27, 2, 3, 3), " +
                "(33, 28, 11, 3, 3), " +
                "(34, 29, 1, 3, 3), " +
                "(35, 30, 21, 2, 3), " +
                "(36, 30, 21, 2, 3), " +
                "(37, 31, 3, 3, 3), " +
                "(38, 32, 22, 2, 3), " +
                "(39, 32, 22, 2, 3), " +
                "(40, 33, 4, 2, 3), " +
                "(41, 33, 4, 2, 3), " +
                "(42, 34, 4, 3, 3)";
            sqlite_cmd.ExecuteNonQuery();
        }


        public static void InsertInDayList()
        {
            sqlite_cmd = con.CreateCommand();

            sqlite_cmd.CommandText = "INSERT INTO DayList (SchedulerID, DayID) VALUES " +
                "(3, 0), " +
                "(4, 1), " +
                "(6, 0), " +
                "(6, 1), " +
                "(6, 2), " +
                "(6, 3), " +
                "(7, 0), " +
                "(7, 1), " +
                "(7, 2), " +
                "(7, 3), " +
                "(9, 1), " +
                "(10, 4), " +
                "(11, 1), " +
                "(11, 2), " +
                "(13, 1), " +
                "(14, 3), " +
                "(18, 3), " +
                "(20, 4), " +
                "(21, 0), " +
                "(22, 0), " +
                "(23, 1), " +
                "(24, 2), " +
                "(26, 2), " +
                "(31, 3), " +
                "(33, 1), " +
                "(34, 0), " +
                "(37, 1), " +
                "(37, 2)";
            sqlite_cmd.ExecuteNonQuery();
        }


        public static void InsertInStartTimeList()
        {
            sqlite_cmd = con.CreateCommand();

            sqlite_cmd.CommandText = "INSERT INTO StartTimeList (SchedulerID, StartTimeID) VALUES " +
                "(1, 3), " +
                "(1, 4), " +
                "(1, 5), " +
                "(1, 6), " +
                "(1, 7), " +
                "(1, 8), " +
                "(1, 9), " +
                "(1, 10), " +
                "(3, 0), " +
                "(4, 0), " +
                "(5, 0), " +
                "(6, 8), " +
                "(7, 10), " +
                "(9, 7), " +
                "(10, 8), " +
                "(13, 1), " +
                "(14, 1), " +
                "(15, 3), " +
                "(15, 4), " +
                "(15, 5), " +
                "(15, 6), " +
                "(15, 7), " +
                "(16, 3), " +
                "(16, 4), " +
                "(16, 5), " +
                "(16, 6), " +
                "(16, 7), " +
                "(18, 1), " +
                "(20, 11), " +
                "(21, 10), " +
                "(22, 4), " +
                "(23, 9), " +
                "(24, 9), " +
                "(26, 3), " +
                "(29, 3), " +
                "(29, 4), " +
                "(29, 5), " +
                "(29, 6), " +
                "(29, 7), " +
                "(29, 8), " +
                "(29, 9), " +
                "(29, 10), " +
                "(29, 11), " +
                "(30, 0), " +
                "(30, 1), " +
                "(30, 2), " +
                "(30, 8), " +
                "(30, 9), " +
                "(30, 10), " +
                "(30, 11), " +
                "(31, 9), " +
                "(33, 10), " +
                "(34, 7), " +
                "(35, 7), " +
                "(35, 8), " +
                "(35, 9), " +
                "(35, 10), " +
                "(35, 11), " +
                "(36, 7), " +
                "(36, 8), " +
                "(36, 9), " +
                "(36, 10), " +
                "(36, 11), " +
                "(38, 7), " +
                "(38, 8), " +
                "(38, 9), " +
                "(38, 10), " +
                "(38, 11), " +
                "(39, 7), " +
                "(39, 8), " +
                "(39, 9), " +
                "(39, 10), " +
                "(39, 11), " +
                "(40, 3), " +
                "(40, 4), " +
                "(40, 5), " +
                "(40, 6), " +
                "(40, 7), " +
                "(41, 3), " +
                "(41, 4), " +
                "(41, 5), " +
                "(41, 6), " +
                "(41, 7), " +
                "(42, 3), " +
                "(42, 4), " +
                "(42, 5), " +
                "(42, 6), " +
                "(42, 7)";
            sqlite_cmd.ExecuteNonQuery();
        }


        public static void InsertInRoomList()
        {
            sqlite_cmd = con.CreateCommand();

            sqlite_cmd.CommandText = "INSERT INTO RoomList (SchedulerID, RoomID) VALUES " +
                "(1, 1), " +
                "(3, 8), " +
                "(4, 8), " +
                "(5, 8), " +
                "(6, 2), " +
                "(7, 2), " +
                "(9, 1), " +
                "(10, 3), " +
                "(11, 1), " +
                "(13, 7), " +
                "(14, 7), " +
                "(15, 2), " +
                "(15, 3), " +
                "(16, 2), " +
                "(16, 3), " +
                "(17, 1), " +
                "(18, 6), " +
                "(19, 1), " +
                "(20, 2), " +
                "(21, 2), " +
                "(22, 2), " +
                "(23, 4), " +
                "(24, 4), " +
                "(25, 2), " +
                "(26, 2), " +
                "(26, 3), " +
                "(27, 2), " +
                "(27, 3), " +
                "(28, 2), " +
                "(28, 3), " +
                "(31, 3), " +
                "(33, 3), " +
                "(34, 2), " +
                "(35, 5), " +
                "(35, 10), " +
                "(36, 5), " +
                "(36, 10), " +
                "(37, 1), " +
                "(38, 8), " +
                "(39, 8), " +
                "(40, 2), " +
                "(40, 3), " +
                "(41, 2), " +
                "(41, 3), " +
                "(42, 2), " +
                "(42, 3)";
            sqlite_cmd.ExecuteNonQuery();
        }


        public static void InsertInDependency()
        {
            sqlite_cmd = con.CreateCommand();

            sqlite_cmd.CommandText = "INSERT INTO Dependency (CourseID, DependentCourseID, InHowManyDays) VALUES " +
                "(1, 29, 1), " +
                "(29, 1, 1), " +
                "(15, 16, 5), " +
                "(15, 40, 5), " +
                "(15, 41, 5), " +
                "(15, 42, 5), " +
                "(16, 15, 5), " +
                "(16, 40, 5), " +
                "(16, 41, 5), " +
                "(16, 42, 5), " +
                "(40, 15, 5), " +
                "(40, 16, 5), " +
                "(40, 41, 5), " +
                "(40, 42, 5), " +
                "(41, 15, 5), " +
                "(41, 16, 5), " +
                "(41, 40, 5), " +
                "(41, 42, 5), " +
                "(42, 15, 5), " +
                "(42, 16, 5), " +
                "(42, 40, 5), " +
                "(42, 41, 5), " +
                "(2, 8, 2), " +
                "(2, 12, 2), " +
                "(2, 32, 2), " +
                "(8, 2, 2), " +
                "(8, 12, 2), " +
                "(8, 32, 2), " +
                "(12, 2, 2), " +
                "(12, 8, 2), " +
                "(12, 32, 2), " +
                "(32, 2, 2), " +
                "(32, 8, 2), " +
                "(32, 12, 2), " +
                "(35, 36, 2), " +
                "(36, 35, 2), " +
                "(38, 39, 2), " +
                "(39, 38, 2), " +
                "(14, 18, 1), " +
                "(18, 14, 1)";
            sqlite_cmd.ExecuteNonQuery();
        }


    }
}