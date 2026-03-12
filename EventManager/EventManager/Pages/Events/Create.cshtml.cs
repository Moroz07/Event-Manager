using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManager.Data;
using EventManager.Model;

namespace EventManager.Pages.Events
{
 
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Event Event { get; set; }
        public void OnGet() {}
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Events.Add(Event);
            _context.SaveChanges();
            return RedirectToPage("Index");

        }
    }
}
