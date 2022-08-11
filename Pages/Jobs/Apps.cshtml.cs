using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tech_Pursuit.Models;

namespace Tech_Pursuit.Pages.Jobs
{
    public class AppsModel : PageModel
    {
        private readonly Tech_Pursuit.Data.ApplicationDbContext _context;

        public AppsModel(Tech_Pursuit.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<AppUser> AppUsers { get; set; }
        
        public async Task<IActionResult> OnGet(int id)
        {
            List<Application> apps = _context.Applications.Where(u => u.JobId == id).ToList();
            List<AppUser> users = new List<AppUser>();
            foreach (var app in apps)
            {
                var u = _context.Users.FirstOrDefault(u => u.UserName == app.UserId);
                users.Add(u);
            }
            AppUsers = users;
            return Page();
        }
    }
}
