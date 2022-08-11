using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tech_Pursuit.Data;
using Tech_Pursuit.Models;

namespace Tech_Pursuit.Pages.Languages
{
    public class DetailsModel : PageModel
    {
        private readonly Tech_Pursuit.Data.ApplicationDbContext _context;

        public DetailsModel(Tech_Pursuit.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Language Language { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Languages == null)
            {
                return NotFound();
            }

            var language = await _context.Languages.FirstOrDefaultAsync(m => m.Id == id);
            if (language == null)
            {
                return NotFound();
            }
            else 
            {
                Language = language;
            }
            return Page();
        }
    }
}
