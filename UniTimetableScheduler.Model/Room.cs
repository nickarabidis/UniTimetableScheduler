
using System.Collections.Generic;

namespace Scheduler.Model
{
    // Stores data about classroom
    public class Room
    {
        // ID counter used to assign IDs automatically
        //private static int _nextRoomId = 0;

        // Initializes room data and assign ID to room
        public Room(int id, string name, bool lab)
        {
            Id = id;
            Name = name;
            Lab = lab;
            CourseClasses = new List<CourseClass>();
        }

        // Bind Room to course
        public void AddCourseClass(CourseClass courseClass)
        {
            CourseClasses.Add(courseClass);
        }
        // Returns room ID - automatically assigned
        public int Id { get; set; }

        // Returns name
        public string Name { get; set; }

        // Returns TRUE if room has computers otherwise it returns FALSE
        public bool Lab { get; set; }

        // Returns number of seats in room
        public int NumberOfSeats { get; set; }

        // Returns reference to list of classes with rooms 
        public List<CourseClass> CourseClasses { get; set; }

        // Restarts ID assigments
        //public static void RestartIDs() { _nextRoomId = 0; }
    }
}
