using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    /// <summary>
    /// Represents the model for the Students Delete page.
    /// </summary>
    public class DeleteModel : PageModel
    {
        /// <summary>
        /// Represents the model for the Students Delete page.
        /// </summary>
        private readonly Data.SchoolContext _context;
        /// <summary>
        /// Logger for the delete operation.
        /// </summary>
        private readonly ILogger<DeleteModel> _logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteModel"/> class.
        /// </summary>
        /// <param name="context">Db content</param>
        /// <param name="logger">logger for delete</param>
        public DeleteModel(Data.SchoolContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        /// <summary>
        /// Represents the student to be deleted.
        /// </summary>
        [BindProperty]
        public Student Student { get; set; } = default!;
        /// <summary>
        /// Error message to display if deletion fails.
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Gets the student details for deletion confirmation.
        /// </summary>
        /// <param name="id">Student id to get</param>
        /// <param name="saveChangesError">Error message if fialed</param>
        /// <returns>Succes as student deletion or error if failed</returns>
        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }
        /// <summary>
        /// Edit or delete students
        /// </summary>
        /// <param name="id">Student id to delete</param>
        /// <returns>Deleted student or error if fialed</returns>
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
        }
    }
}
