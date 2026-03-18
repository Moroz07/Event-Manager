using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManager.Data;
using EventManager.Model;

namespace EventManager.Pages.Participants
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public EventParticipsnt? Participant { get; set; }

        public IActionResult OnGet(int id)
        {
            Participant = _context.EventsParticipsnt.FirstOrDefault(p => p.Id == id);

            if (Participant == null)
                return NotFound();

            return Page();
        }
    }
}