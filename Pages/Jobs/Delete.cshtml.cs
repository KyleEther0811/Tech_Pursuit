using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tech_Pursuit.Data;
using Tech_Pursuit.Models;

namespace Tech_Pursuit.Pages.Jobs
{
    public class DeleteModel : PageModel
    {
        private readonly Tech_Pursuit.Data.ApplicationDbContext _context;

        public DeleteModel(Tech_Pursuit.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public JobModel JobModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.JobModels == null)
            {
                return NotFound();
            }

            var jobmodel = await _context.JobModels.FirstOrDefaultAsync(m => m.Id == id);

            if (jobmodel == null)
            {
                return NotFound();
            }
            else 
            {
                JobModel = jobmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.JobModels == null)
            {
                return NotFound();
            }
            var jobmodel = await _context.JobModels.FindAsync(id);

            if (jobmodel != null)
            {
                JobModel = jobmodel;
                _context.JobModels.Remove(JobModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
