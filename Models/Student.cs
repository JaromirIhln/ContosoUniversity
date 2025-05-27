using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        /// <summary>
        /// Gets or sets the first and middle name of the student.
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string? FirstMidName { get; set; }
        /// <summary>
        /// Gets or sets the date when the student enrolled in the university.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        /// <summary>
        /// Gets the full name of the student in the format "LastName, FirstMidName".
        /// </summary>
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
        // Navigation property
        /// <summary>
        /// Gets or sets the collection of enrollments associated with the student.
        /// </summary>
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
