using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManager.Data;
using EventManager.Model;

namespace EventManager.Pages.EventParticipants
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context) => _context = context;
        [BindProperty] public EventParticipsnt Participant { get; set; }
        public void OnGet() { }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _context.EventsParticipsnt.Add(Participant);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}