using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Tech_Pursuit.Data;
using Tech_Pursuit.Models;

namespace Tech_Pursuit.Pages
{
    public class IndexModel : PageModel
    {

        // Pass Job Data to Table on Index Page 
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-DCRFQJV2;Initial Catalog=Tech_Pursuit;Integrated Security=True");
        // Jobs List 
        public List<JobModel> jobList = new List<JobModel>();     
        ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;                      
        }

        public string JobTitleSort { get; set; }
        public string JobDescriptionSort { get; set; }
        public string RequiredSkillsSort { get; set; }
        public string CitySort { get; set; }
        public string StateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        

        //Sorting / Filter for Job Lists on front Page
        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            jobList = _db.JobModels.ToList(); // read
            JobTitleSort = String.IsNullOrEmpty(sortOrder) ? "jobtitle_desc" : "Job Title";
            JobDescriptionSort = sortOrder == "Keywords" ? "jobdescription_desc" : "Job Description";
            RequiredSkillsSort = sortOrder == "Skills" ? "RequiredSkills_desc" : "Required Skills";
            CitySort = sortOrder == "city" ? "City_desc" : "City";
            StateSort = sortOrder == "state" ? "State_desc" : "State";

            CurrentFilter = searchString;

            IQueryable<JobModel> jobs = from s in _db.JobModels
                                    select s;
            // If Statement for Search bar
            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(s => s.JobTitle.Contains(searchString) ||
                    s.RequiredSkills.Contains(searchString) ||
                    s.State.Contains(searchString) ||
                    s.City.Contains(searchString));                                                                  
            }
            // Switch Statement to Display Jobs List in specific order
            switch (sortOrder)
            {
                case "jobtitle_desc":
                    jobs = jobs.OrderByDescending(s => s.JobTitle);
                    break;                
                case "jobdescription_desc":
                    jobs = jobs.OrderByDescending(s => s.JobDescription);
                    break;
                case "RequiredSkills_desc":
                    jobs = jobs.OrderByDescending(s => s.RequiredSkills);
                    break;
                case "City_desc":
                    jobs = jobs.OrderByDescending(s => s.City);
                    break;
                case "Sate_desc":
                    jobs = jobs.OrderByDescending(s => s.State);
                    break;
                default:
                    jobs = jobs.OrderBy(s => s.JobTitle);
                    break;
            }
            jobList = await jobs.AsNoTracking().ToListAsync();
        }            
                         
    }
}