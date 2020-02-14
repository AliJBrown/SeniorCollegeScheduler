using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_College_Project.Models.ViewModels
{
    public class ClassDetailedViewModel
    {
        //Still need prefered time variables
        public DateTime ProposedDate { get; set; }
        public string ProposedTitle { get; set; }
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
        public int MinStudentCount { get; set; }
        public int MaxStudentCount { get; set; }
        public int TablesNeeded { get; set; }
        public int ChairsNeeded { get; set; }
        public string OtherEquipmentNeeded { get; set; }
        public double HandoutCost { get; set; }
        public string StipendRequested { get; set; }
    }
}
