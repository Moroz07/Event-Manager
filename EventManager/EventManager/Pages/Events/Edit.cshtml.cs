using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManager.Data;
using EventManager.Model;

namespace EventManager.Pages.Events
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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
            if (!ModelState.IsValid)
                return Page();

            _context.Events.Update(Event);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}