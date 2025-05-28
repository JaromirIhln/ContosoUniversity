using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models.SchoolViewModels
{
    /// <summary>
    /// Represents the data model for displaying a list of instructors
    /// along with their associated courses and enrollments.
    /// </summary>
    public class InstructorIndexData
    {
        /// <summary>
        /// Represents the collection of instructors to be displayed.
        /// </summary>
        public IEnumerable<Instructor> Instructors { get; set; }
        /// <summary>
        /// Represents the collection of courses associated with the instructors.
        /// </summary>
        public IEnumerable<Course> Courses { get; set; }
        /// <summary>
        /// Represents the collection of enrollments associated with the courses.
        /// </summary>
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}