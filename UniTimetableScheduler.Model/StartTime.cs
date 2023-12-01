using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    // Stores data about startTime
    public class StartTime
    {
        // Initializes startTime data
        public StartTime(int id, string name)
        {
            Id = id;
            Name = name;
            CourseClasses = new List<CourseClass>();
        }

        // Bind startTime to course
        public void AddCourseClass(CourseClass courseClass)
        {
            CourseClasses.Add(courseClass);
        }

        public override bool Equals(object obj)
        {
            return obj is StartTime startTime &&
                   Id == startTime.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        // Returns startTime's ID
        public int Id { get; set; }

        // Returns startTime's name
        public string Name { get; set; }

        // Returns reference to list of classes with their startTimes
        public List<CourseClass> CourseClasses { get; set; }

    }
}
