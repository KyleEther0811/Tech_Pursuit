using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Tech_Pursuit.Data;
using Tech_Pursuit.Models;

namespace Tech_Pursuit.Pages
{
    public class UserModel : PageModel
    {

        // Pass Job Data to Table on Index Page 
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-DCRFQJV2;Initial Catalog=Tech_Pursuit;Integrated Security=True");
        // Users List
        public List<AppUser> userList = new List<AppUser>();     
        ApplicationDbContext _db;

        public UserModel(ApplicationDbContext db)
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
            userList = _db.UserModels.ToList();           
            JobTitleSort = String.IsNullOrEmpty(sortOrder) ? "fname_desc" : "First Name";
            JobDescriptionSort = sortOrder == "Keywords" ? "lname_desc" : "Last Name";
            RequiredSkillsSort = sortOrder == "Skills" ? "jobtitle_desc" : "Job Title";
            CitySort = sortOrder == "city" ? "City_desc" : "City";
            StateSort = sortOrder == "state" ? "State_desc" : "State";

            CurrentFilter = searchString;

            IQueryable<AppUser> users = from s in _db.UserModels
                                    select s;
            // If Statement for Search bar
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.FirstName.Contains(searchString) ||
                    s.JobTitle.Contains(searchString) ||
                    s.AboutMe.Contains(searchString) ||
                    s.State.Contains(searchString) ||
                    s.City.Contains(searchString));                                                                  
            }
            // Switch Statement to Display Jobs List in specific order
            switch (sortOrder)
            {
                case "jobtitle_desc":
                    users = users.OrderByDescending(s => s.AboutMe);
                    break;                
                case "jobdescription_desc":
                    users = users.OrderByDescending(s => s.JobTitle);
                    break;
                case "RequiredSkills_desc":
                    users = users.OrderByDescending(s => s.HeadLine);
                    break;
                case "City_desc":
                    users = users.OrderByDescending(s => s.City);
                    break;
                case "Sate_desc":
                    users = users.OrderByDescending(s => s.State);
                    break;
                default:
                    users = users.OrderByDescending(s => s.AboutMe);
                    break;
            }
            userList = await users.AsNoTracking().ToListAsync();
        }            
                         
    }
}