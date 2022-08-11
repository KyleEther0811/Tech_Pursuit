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
    public class IndexModel : PageModel
    {
        private readonly Tech_Pursuit.Data.ApplicationDbContext _context;

        public IndexModel(Tech_Pursuit.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<JobModel> JobModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.JobModels != null)
            {
                JobModel = await _context.JobModels.ToListAsync();
            }
        }
    }
}
