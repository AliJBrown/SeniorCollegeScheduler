using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_College_Project.Models.ViewModels
{
    public class FormCreationViewModel
{
        public String ProposedTitle { get; set; }
        public int NumberOfSessions { get; set; }
        public int LengthOfSession { get; set; }
        public String CourseDescription { get; set; }
        public String PreRequisite { get; set; }
        //add Prefered Sessions times
        public String UnavailableTimes { get; set; }
        public int MinStudentCount { get; set; }
        public int MaxStudentCount { get; set; }

        [Range(0,100)]
        public int ChairsNeeded { get; set; }
        public int TablesNeeded { get; set; }
        //add Equipment needed
        public int OtherEquipmentNeeded { get; set; }
        public double HandoutCost { get; set; }
        
        public String StipendRequested { get; set; }

}
}
