using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tech_Pursuit.Data;
using Tech_Pursuit.Models;

namespace Tech_Pursuit.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly Tech_Pursuit.Data.ApplicationDbContext _context;

        public EditModel(Tech_Pursuit.Data.ApplicationDbContext context)
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

            var jobmodel =  await _context.JobModels.FirstOrDefaultAsync(m => m.Id == id);
            if (jobmodel == null)
            {
                return NotFound();
            }
            JobModel = jobmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(JobModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobModelExists(JobModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobModelExists(int id)
        {
          return (_context.JobModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
