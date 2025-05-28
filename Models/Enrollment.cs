using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    /// <summary>
    /// Represents an enrollment in a course for a student.
    /// </summary>
    public enum Grade
    {
        A, B, C, D, F
    }
    /// <summary>
    /// Represents an enrollment record that links a 
    /// student to a course and includes the student's grade.
    /// </summary>
    public class Enrollment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the enrollment record.
        /// </summary>
        public int EnrollmentID { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier for the course associated with the enrollment.
        /// </summary>
        public int CourseID { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier for the student associated with the enrollment.
        /// </summary>
        public int StudentID { get; set; }
        /// <summary>
        /// Gets or sets the grade received by the student in the course.
        /// </summary>
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
        // Navigation property
        /// <summary>
        /// Gets or sets the course associated with the enrollment.
        /// </summary>
        public Course? Course { get; set; }
        /// <summary>
        /// Gets or sets the student associated with the enrollment.
        /// </summary>
        public Student? Student { get; set; }
    }
}
