namespace ContosoUniversity.Models
{
    /// <summary>
    /// Represents a student in the Contoso University system.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the unique identifier for the student.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets the last name of the student.
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Gets or sets the first and middle name of the student.
        /// </summary>
        public string? FirstMidName { get; set; }
        /// <summary>
        /// Gets or sets the date when the student enrolled in the university.
        /// </summary>
        public DateTime EnrollmentDate { get; set; }

        /// <summary>
        /// Gets or sets the collection of enrollments associated with the student.
        /// </summary>
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
