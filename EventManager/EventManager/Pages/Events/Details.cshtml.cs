using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManager.Data;
using EventManager.Model;


namespace EventManager.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Event Event { get; set; }


        public IActionResult OnGet(int id)
        {
            Event = _context.Events.FirstOrDefault(s => s.Id == id);

            if (Event == null)
                return NotFound();

            return Page();
        }
    }
}
