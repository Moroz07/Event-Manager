using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManager.Data;
using EventManager.Model.AuthApp;

namespace EventManager.Pages.Account.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuthUser User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Заполняем Name из Email
            if (User != null && !string.IsNullOrEmpty(User.Email))
            {
                User.Name = User.Email;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AuthUsers.Add(User);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}