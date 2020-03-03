using SeniorCollegeScheduler.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorCollegeScheduler.Models.ViewModels
{
    public class UserSummaryViewModel
    {
        public string UserId { get; set; }
        public string InstructorName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string MobilePhone { get; set; }

        public static UserSummaryViewModel FromMyIdentityUser(MyIdentityUser user)
        {
            return new UserSummaryViewModel
            {
                State = user.State,
                City = user.City,
                MobilePhone = user.MobilePhone
            };
        }
    }
}
