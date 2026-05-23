using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventManager.Data;
using EventManager.Model.AuthApp;

namespace EventManager.Pages.Account.Users
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuthUser User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _context.AuthUsers.FindAsync(id);

            if (User == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile? AvatarFile)
        {
            // Заполняем Name из Email, если пустой
            if (string.IsNullOrEmpty(User.Name) && !string.IsNullOrEmpty(User.Email))
            {
                User.Name = User.Email;
            }

            // Обновляем аватар, если загружен новый файл
            if (AvatarFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await AvatarFile.CopyToAsync(memoryStream);
                    User.Avatar = memoryStream.ToArray();
                }
            }

            if (!ModelState.IsValid)
                return Page();

            _context.Attach(User).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}