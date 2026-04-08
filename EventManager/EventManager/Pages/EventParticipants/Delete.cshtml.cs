using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManager.Data;
using EventManager.Model;

namespace EventManager.Pages.EventParticipants
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context) => _context = context;
        [BindProperty] public EventParticipsnt Participant { get; set; }
        public IActionResult OnGet(int id)
        {
            Participant = _context.EventsParticipsnt.Find(id);
            if (Participant == null) return NotFound();
            return Page();
        }
        public IActionResult OnPost()
        {
            var participant = _context.EventsParticipsnt.Find(Participant.Id);
            if (participant != null)
            {
                _context.EventsParticipsnt.Remove(participant);
                _context.SaveChanges();
            }
            return RedirectToPage("Index");
        }
    }
}