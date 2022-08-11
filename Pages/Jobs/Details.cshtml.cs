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
    public class DetailsModel : PageModel
    {
        private readonly Tech_Pursuit.Data.ApplicationDbContext _context;

        public DetailsModel(Tech_Pursuit.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
      public JobModel JobModel { get; set; } = default!;
        [TempData]
        public string StatusMessage { get; set; }
        public bool IsSubmitted { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        { 
            IsSubmitted = false;
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
        public async Task<IActionResult> OnPostAsync()
        {
            Application app = new Application();
            app.JobId = JobModel.Id;
            app.UserId = User.Identity.Name;
            _context.Applications.Add(app);
            await _context.SaveChangesAsync();          
            IsSubmitted = true;
           
            return RedirectToPage("/Index");
        }
    }
}
