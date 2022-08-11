using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tech_Pursuit.Models;
using Tech_Pursuit.Pages;

namespace Tech_Pursuit.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<JobModel> JobModels { get; set; }
        public DbSet<AppUser> UserModels{ get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Language> Languages { get; set; }  

    }
}