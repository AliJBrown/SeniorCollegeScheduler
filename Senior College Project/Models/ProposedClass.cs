using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_College_Project.Models.ViewModels
{
    public class ProposedClass
{
        public int ProposedID { get; set; }
        public DateTime ProposedDate { get; set; }
        public String ProposedTitle { get; set; }
        public int NumberOfSessions { get; set; }
        public int LengthOfSession { get; set; }
        public string CourseDescription { get; set; }
        public string PreRequisite { get; set; }
        //add Prefered Sessions times
        public string UnavailableTimes { get; set; }
        public int MinStudentCount { get; set; }
        public int MaxStudentCount { get; set; }

        [Range(0,100)]
        public int ChairsNeeded { get; set; }
        public int TablesNeeded { get; set; }
        //add Equipment needed
        public string OtherEquipmentNeeded { get; set; }
        public double HandoutCost { get; set; }
        public string StipendRequested { get; set; }

        //Need these to fill class summary view model information. or grab them from accounts
        public string ProposedByInstructor { get; set; }
        public string City { get; set; }

}
}
