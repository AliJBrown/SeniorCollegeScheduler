using SeniorCollegeScheduler.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorCollegeScheduler.Models.ViewModels
{
    public class CreateInstructorCommand
    {

        [Required, StringLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, StringLength(25)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, StringLength(45)]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Required, StringLength(25)]
        public string City { get; set; }
        [Required, StringLength(2)]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required, StringLength(5)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public string ShareEmail { get; set; }
        public string ShareMobilePhone { get; set; }
        public string ShareLandline { get; set; }
        [StringLength(10)]
        [Display(Name = "Landline Phone")]
        public string LandlinePhone { get; set; }
        [StringLength(10)]
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }
        [Required]
        [Display(Name ="Instructor Bio")]
        public string InstructorBio { get; set; }

        public User ToUser()
        {
            return new User
            {
                FirstName = FirstName,
                LastName = LastName,
                StreetAddress = StreetAddress,
                City = City,
                State = State,
                ZipCode = ZipCode,
                LandlinePhone = LandlinePhone,
                MobilePhone = MobilePhone,
                InstructorBio = InstructorBio,
                IsFiled = true,
                
            };
        }
    }
}
