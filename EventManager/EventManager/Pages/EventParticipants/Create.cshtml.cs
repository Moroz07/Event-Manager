using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventManager.Data;
using EventManager.Model;
using System.Linq;

namespace EventManager.Pages.EventParticipants
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventParticipsnt Participant { get; set; }

        public List<SelectListItem> EventsList { get; set; }

        public void OnGet()
        {
            LoadEventsList();
        }

        private void LoadEventsList()
        {
            EventsList = _context.Events
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = $"{e.Name} (дата: {e.EventDate.ToShortDateString()}, место: {e.location})"
                })
                .ToList();
        }

        public IActionResult OnPost()
        {
            var temp = Participant;

            if (!ModelState.IsValid)
            {
                LoadEventsList();
                return Page();
            }

            _context.EventsParticipsnt.Add(Participant);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}