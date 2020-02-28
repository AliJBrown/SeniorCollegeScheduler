using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorCollegeScheduler.Models.DataModels
{
    public class User
    {
        [Key]
        public Guid InstructorId { get; set; }
        [StringLength(25)]
        public string FirstName { get; set; }
        [StringLength(25)]
        public string LastName { get; set; }
        [StringLength(45)]
        public string StreetAddress { get; set; }
        [StringLength(25)]
        public string city { get; set; }
        [StringLength(2)]
        public string State { get; set; }
        [StringLength(5)]
        public string ZipCode { get; set; }
        public bool ShareEmail { get; set; }
        public bool ShareMobilePhone { get; set; }
        public bool ShareLandline { get; set; }
        [StringLength(10)]
        public string LandlinePhone { get; set; }
        [StringLength(10)]
        public string MobilePhone { get; set; }
        public string InstructorBio { get; set; }

    }
}
