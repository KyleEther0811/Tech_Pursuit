using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tech_Pursuit.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Job Title"), MaxLength(60)]
        public string? JobTitle { get; set; }
        
        [Display(Name = "About Me"), MaxLength (300)]
        public string? AboutMe { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string? LinkedIn { get; set; }
        public string? GitHub { get; set; }
        [Display(Name = "Headline"), MaxLength(100)]
        public string? HeadLine { get; set; }
        [Display(Name = "Profile Picture")]
        public string? ProfilePic { get; set; }


        public List<Language>? Languages { get; set; }

        internal static object AsNoTracking()
        {
            throw new NotImplementedException();
        }
    }
}
