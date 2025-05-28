using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    /// <summary>
    /// Represents a course in the school system.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Gets or sets the unique identifier for the course.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }
        /// <summary>
        /// Gets or sets the title of the course.
        /// </summary>
        [StringLength(50, MinimumLength = 3)]
        public string? Title { get; set; }
        /// <summary>
        /// Gets or sets the number of credits awarded for completing the course.
        /// </summary>
        [Range(0, 5)]
        public int Credits { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier(FK) for the department that offers the course.
        /// </summary>
        public int DepartmentID { get; set; }

        // Navigation property
        /// <summary>
        /// Gets or sets the collection of enrollments associated with the course.
        /// </summary>
        public ICollection<Enrollment>? Enrollments { get; set; }
        public Department Department { get; set; } = null!; // Department not exist yet, created later in the Models/Department.cs
        public ICollection<Instructor>? Instructors { get; set; }
    }
}
