using System.ComponentModel.DataAnnotations;

namespace Tech_Pursuit.Models
{
    public class JobModel
    {
        
        public int Id { get; set; }
        [Display(Name = "Company Name"), MaxLength(60)]
        public string CompanyName { get; set; }
        //Write a summary of your company/team
        [Display(Name = "Company Summary"), MaxLength(500)]
        public string AboutCompany { get; set; }
        [Display(Name = "Company Website")]
        public string? CompanyWebsite { get; set; }
        [Display(Name = "Job Description"), MaxLength(500)]
        public string JobDescription { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        // Write What skills/Technologies you require for this role.
        [Display(Name = "Required Skills")]
        public string RequiredSkills { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Pay Rate")]
        public double PayRate { get; set; }
        // List Benefits your company/team offers
        [Display(Name = "Additional Benefits")]
        public string? Benefits { get; set; }
        public string UserID { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
