using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManager.Data;
using EventManager.Model;

namespace EventManager.Pages.Events
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; }

        public IActionResult OnGet(int id)
        {
            Event = _context.Events.Find(id);

            if (Event == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var eventToDelete = _context.Events.Find(Event.Id);

            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}