using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_College_Project.Models.AccountViewModels
{
    public class RegisterViewModel
{
        [Required]
        [StringLength(50, ErrorMessage = "Must be less then 50 Characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Must be less then 50 Characters")]
        public string LastName { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Must be less then 45 Characters")]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "City Must be less then 25 characters")]
        public string City { get; set; }

        [Required]
        [StringLength(2, ErrorMessage ="Must be 2 digit state code")]
        public string State { get; set; }

        [Required]
        [StringLength(5, ErrorMessage ="Please enter 5 digit zip code")]
        public string ZipCode { get; set; }

        //ADD BOOLEANS FOR EMAIL, PHONE, MOBILE

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Landline Phone")]
        public string Phone { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Mobile Phone")]
        public string Mobile { get; set; }

        public string InstructorBio { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        


    }
}
