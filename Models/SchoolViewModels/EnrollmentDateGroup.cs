using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models.SchoolViewModels
{
    /// <summary>
    /// Represents a group of students enrolled on a specific date.
    /// </summary>
    public class EnrollmentDateGroup
    {
        /// <summary>
        /// Represents the enrollment date for a group of students.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }
        /// <summary>
        /// Represents the number of students enrolled on the specified enrollment date.
        /// </summary>
        public int StudentCount { get; set; }
    }
}
