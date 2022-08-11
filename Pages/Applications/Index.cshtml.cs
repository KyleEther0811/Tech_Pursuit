using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tech_Pursuit.Data;
using Tech_Pursuit.Models;

namespace Tech_Pursuit.Pages.Applications
{
    public class IndexModel : PageModel
    {
        private readonly Tech_Pursuit.Data.ApplicationDbContext _context;

        public IndexModel(Tech_Pursuit.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Application> Application { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Applications != null)
            {
                Application = await _context.Applications.ToListAsync();
            }
        }
    }
}
