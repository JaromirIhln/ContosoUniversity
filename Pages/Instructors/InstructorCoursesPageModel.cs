using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoUniversity.Pages.Instructors
{
    /// <summary>
    /// Represents the page model for displaying and managing courses assigned to an instructor.
    /// </summary>
    public class InstructorCoursesPageModel : PageModel
    {
        /// <summary>
        /// Represents a list of courses assigned to an instructor, including their IDs, titles, and assignment status.
        /// </summary>
        public List<AssignedCourseData> AssignedCourseDataList;
        /// <summary>
        /// Populates the list of assigned courses for a given instructor from the database context.
        /// </summary>
        /// <param name="context">Db context</param>
        /// <param name="instructor">Instructor entity</param>
        public void PopulateAssignedCourseData(SchoolContext context,
                                               Instructor instructor)
        {
            var allCourses = context.Courses;
            var instructorCourses = new HashSet<int>(instructor.Courses.Select(c => c.CourseID));
            AssignedCourseDataList = [];
            foreach (var course in allCourses)
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                AssignedCourseDataList.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
#pragma warning restore CS8601 // Possible null reference assignment.
            }
        }
    }
}