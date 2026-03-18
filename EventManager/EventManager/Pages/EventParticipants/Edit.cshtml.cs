using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManager.Data;
using EventManager.Model;

namespace EventManager.Pages.Participants
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventParticipsnt? Participant { get; set; }

        public IActionResult OnGet(int id)
        {
            Participant = _context.EventsParticipsnt.FirstOrDefault(p => p.Id == id);

            if (Participant == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.EventsParticipsnt.Update(Participant);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}