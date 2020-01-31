using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_College_Project.Models.ViewModels 
{
    public class CreateClassCommand
{
        public DateTime TodaysDate { get; set; }
        public string ProposedTitle { get; set; }
        public string InstructorName { get; set; }
        public string MailingAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string LandPhone { get; set; }
        public string CellPhone { get; set; }
        public string EMail { get; set; }
        public int NumClassSessions { get; set; }
        public int LengthOfSession { get; set; }
        public string ClassDesc { get; set; }
        public string PreRequisites { get; set; }
    }
}
