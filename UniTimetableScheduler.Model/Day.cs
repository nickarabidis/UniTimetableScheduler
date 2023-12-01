using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    // Stores data about day
    public class Day
    {
        // Initializes day data
        public Day(int id, string name)
        {
            Id = id;
            Name = name;
            CourseClasses = new List<CourseClass>();
        }

        // Bind day to course
        public void AddCourseClass(CourseClass courseClass)
        {
            CourseClasses.Add(courseClass);
        }

        public override bool Equals(object obj)
        {
            return obj is Day day &&
                   Id == day.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        // Returns day's ID
        public int Id { get; set; }

        // Returns day's name
        public string Name { get; set; }

        // Returns reference to list of classes with their day
        public List<CourseClass> CourseClasses { get; set; }

    }
}
