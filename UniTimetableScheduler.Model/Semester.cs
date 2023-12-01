using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    // Stores data about semester
    public class Semester
    {
        // Initializes semester data
        public Semester(int id, string name)
        {
            Id = id;
            Name = name;
            CourseClasses = new List<CourseClass>();
        }

        // Bind semester to course
        public void AddCourseClass(CourseClass courseClass)
        {
            CourseClasses.Add(courseClass);
        }

        public override bool Equals(object obj)
        {
            return obj is Semester semester &&
                   Id == semester.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        // Returns semester's ID
        public int Id { get; set; }

        // Returns semester's name
        public string Name { get; set; }

        // Returns reference to list of classes with their semester
        public List<CourseClass> CourseClasses { get; set; }

    }
}
