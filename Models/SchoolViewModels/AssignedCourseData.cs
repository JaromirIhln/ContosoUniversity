namespace ContosoUniversity.Models.SchoolViewModels
{
    /// <summary>
    /// Represents the data model for displaying assigned courses
    /// </summary>
    public class AssignedCourseData
    {
        /// <summary>
        /// Gets or sets the unique identifier for the course.
        /// </summary>
        public int CourseID { get; set; }
        /// <summary>
        /// Gets or sets the title of the course.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the number of credits awarded for completing the course.
        /// </summary>
        public bool Assigned { get; set; }
    }
}