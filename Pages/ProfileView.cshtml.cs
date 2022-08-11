using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Tech_Pursuit.Data;
using Tech_Pursuit.Models;

namespace Tech_Pursuit.Pages
{
    public class ProfileView : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ProfileView(ApplicationDbContext context)
        {
            _context = context;
        }

        public AppUser ProfileUser { get; set; } = default!;
   
        //On Get must take in "id" cannot be any other varible name - HAS TO BE "id" (string, int, double, float - still named "id")
        public async Task OnGetAsync(string? id)
        {
            AppUser appUser = (await _context.Users.FirstOrDefaultAsync(u => u.UserName == id));
            ProfileUser = appUser;
        }
    }
}