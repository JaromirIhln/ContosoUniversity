using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    /// <summary>
    /// Represents the model for the Students Index page.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;
        private readonly IConfiguration Configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="configuration">The configuration settings.</param>
        public IndexModel(SchoolContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        /// <summary>
        /// Gets or sets the sort order for the student list.
        /// </summary>
        public string NameSort { get; set; }
        /// <summary>
        /// Gets or sets the date sort order for the student list.
        /// </summary>
        public string DateSort { get; set; }
        /// <summary>
        /// Gets or sets the current filter string for searching students.
        /// </summary>
        public string CurrentFilter { get; set; }
        /// <summary>
        /// Gets or sets the current sort order for the student list.
        /// </summary>
        public string CurrentSort { get; set; }

        public PaginatedList<Student> Students { get; set; }

        /// <summary>
        /// Handles the GET request for the Students Index page.
        /// </summary>
      //  public IList<Student> Students { get; set; }

        public async Task OnGetAsync(string sortOrder,string currentFilter, string searchString, int? pageIndex)
        {
            // using System;
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            IQueryable<Student> studentsIQ = from s in _context.Students 
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
            }

            switch (sortOrder)
        {
            case "name_desc":
                studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                break;
            case "Date":
                studentsIQ = studentsIQ.OrderBy(s => s.EnrollmentDate);
                break;
            case "date_desc":
                studentsIQ = studentsIQ.OrderByDescending(s => s.EnrollmentDate);
                break;
            default:
                studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                break;
        }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Students = await PaginatedList<Student>.CreateAsync(
            studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
