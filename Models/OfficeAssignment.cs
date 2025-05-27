﻿using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; } = string.Empty;

        // Navigation property
        public Instructor Instructor { get; set; } = null!; // Non-nullable reference type, must be initialized
    }
}
