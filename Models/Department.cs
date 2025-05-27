using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    /// <summary>
    /// Represents a department in the Contoso University system.
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Gets or sets the unique identifier for the department.
        /// </summary>
        public int DepartmentID { get; set; }
        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        /// <summary>
        ///Gets or sets the unique identifier for the administrator (instructor) of the department.
        /// </summary>
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }
        /// <summary>
        /// Gets or sets the date when the department was established.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier (FK) for the instructor who is the administrator of the department.
        /// </summary>
        public int? InstructorID { get; set; }
        // Navigation properties
        /// <summary>
        /// Gets or sets the instructor who is the administrator of the department.
        /// </summary>
        public Instructor Administrator { get; set; }
        /// <summary>
        /// Gets or sets the collection of courses offered by the department.
        /// </summary>
        public ICollection<Course> Courses { get; set; }
    }
}
