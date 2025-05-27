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
        public int? CourseID { get; set; }
        /// <summary>
        /// Gets or sets the title of the course.
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Gets or sets the number of credits awarded for completing the course.
        /// </summary>
        public int? Credits { get; set; }

        // Navigation property
        /// <summary>
        /// Gets or sets the collection of enrollments associated with the course.
        /// </summary>
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
