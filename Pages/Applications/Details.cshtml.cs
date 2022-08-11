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
    public class DetailsModel : PageModel
    {
        private readonly Tech_Pursuit.Data.ApplicationDbContext _context;

        public DetailsModel(Tech_Pursuit.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Application Application { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {           

            var application = await _context.Applications.FirstOrDefaultAsync(m => m.JobId == id);
            if (application == null)
            {
                return NotFound();
            }
            else 
            {
                Application = application;
            }
            return Page();
        }
    }
}
