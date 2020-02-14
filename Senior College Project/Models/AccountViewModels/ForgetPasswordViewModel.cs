using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_College_Project.Models.AccountViewModels
{
    public class ForgetPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
}
