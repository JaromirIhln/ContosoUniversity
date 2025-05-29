using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    /// <summary>
    /// Represents an instructor in the Contoso University system.
    /// </summary>
    public class Instructor
    {
        /// <summary>
        /// Gets or sets the unique identifier for the instructor.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets the last name of the instructor.
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the first name of the instructor.
        /// </summary>
        [Required]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstMidName { get; set; }
        /// <summary>
        /// Gets or sets the hire date of the instructor.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        /// <summary>
        /// Gets the full name of the instructor, formatted as "LastName, FirstMidName".
        /// </summary>
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstMidName; }
        }

        // Navigation property

        public ICollection<Course> Courses { get; set; } // don't init
        public OfficeAssignment OfficeAssignment { get; set; }// Is not exist - created later in the course
    }
}
