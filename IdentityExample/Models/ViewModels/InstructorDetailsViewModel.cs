using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorCollegeScheduler.Models.ViewModels
{
    public class InstructorDetailsViewModel
    {
        public int id { get; set; }

        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        
        public string City { get; set; }
        
        [Display(Name = "State")]
        public string State { get; set; }
        
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public bool ShareEmail { get; set; }
        public bool ShareMobilePhone { get; set; }
        public bool ShareLandline { get; set; }
        
        [Display(Name = "Landline Phone")]
        public string LandlinePhone { get; set; }
        
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }
        
        [Display(Name = "Instructor Bio")]
        public string InstructorBio { get; set; }
    }
}
