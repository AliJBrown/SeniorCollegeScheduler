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
        public string ProposedTitle { get; set; }
        public int NumberOfSessions { get; set; }
        public int LengthOfSession { get; set; }
        public string CourseDescription { get; set; }
        public string PreRequisite { get; set; }
        public string UnavailableTimes { get; set; }
        public int MinStudentCount { get; set; }
        public int MaxStudentCount { get; set; }

        [Range(0,100)]
        public int ChairsNeeded { get; set; }
        public int TablesNeeded { get; set; }
        public double HandoutCost { get; set; }
        public bool StipendRequested { get; set; }

        //Equipment needed
        public string OtherEquipmentNeeded { get; set; }
        public bool InternetConnection { get; set; }
        public bool DryEraseBoard { get; set; }
        public bool ProjectorWithScreen { get; set; }
        public string PCConnectionType { get; set; }
        public bool MicrophoneAndSound { get; set; }
        public bool DVDAndVCRPlayer { get; set; }

        //PREFERED TIMES MONDAY
        public bool MondayEvening { get; set; }
        public bool MondayMorning { get; set; }
        public bool MondayAfternoon { get; set; }

        //PREFERED TIMES Tuesday
        public bool TuesdayEvening { get; set; }
        public bool TuesdayMorning { get; set; }
        public bool TuesdayAfternoon { get; set; }

        //PREFERED TIMES Wednesday
        public bool WednesdayEvening { get; set; }
        public bool WednesdayMorning { get; set; }
        public bool WednesdayAfternoon { get; set; }

        //PREFERED TIMES Thursday
        public bool ThursdayEvening { get; set; }
        public bool ThursdayMorning { get; set; }
        public bool ThursdayAfternoon { get; set; }

        //PREFERED TIMES Friday
        public bool FridayEvening { get; set; }
        public bool FridayMorning { get; set; }
        public bool FridayAfternoon { get; set; }

        //PREFERED TIMES Saturday
        public bool SaturdayEvening { get; set; }
        public bool SaturdayMorning { get; set; }
        public bool SaturdayAfternoon { get; set; }

        //PREFERED TIMES Sunday
        public bool SundayEvening { get; set; }
        public bool SundayMorning { get; set; }
        public bool SundayAfternoon { get; set; }


    }
}
