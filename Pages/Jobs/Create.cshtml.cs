using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tech_Pursuit.Data;
using Tech_Pursuit.Models;

namespace Tech_Pursuit.Pages.Jobs
{
    public class CreateModel : PageModel
    {
        private readonly Tech_Pursuit.Data.ApplicationDbContext _context;

        public CreateModel(Tech_Pursuit.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobModel JobModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            JobModel.UserID = User.Identity.Name;

            _context.JobModels.Add(JobModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
