using System;

namespace SeniorCollegeScheduler.Models.ViewModels
{
    public class ClassDetailedViewModel
    {
        public DateTime ProposedDate { get; set; }
        public string ProposedById { get; set; }
        public int ProposalId { get; set; }
        public string ProposedTitle { get; set; }
        public bool IsReviewed { get; set; }
        public int NumClassSessions { get; set; }
        public int LengthOfSession { get; set; }
        public string ClassDesc { get; set; }
        public string PreRequisites { get; set; }
        public int MinStudentCount { get; set; }
        public int MaxStudentCount { get; set; }
        public int TablesNeeded { get; set; }
        public int ChairsNeeded { get; set; }
        public double HandoutCost { get; set; }
        public bool StipendRequested { get; set; }

        //Equipment Needed
        public string OtherEquipmentNeeded { get; set; }
        public bool InternetConnection { get; set; }
        public bool DryEraseWithMarkers { get; set; }
        public bool ProjectorWithScreen { get; set; }
        public string PCConnectionType { get; set; }
        public bool MicrophoneWithSoundSystem { get; set; }
        public bool VCROrDVDWithScreen { get; set; }
        public bool Podium { get; set; }

        //Prefered Times Variables
        public string DateTimeRestrictions { get; set; }

        //Monday
        public bool MondayMorning { get; set; }
        public bool MondayAfternoon { get; set; }
        public bool MondayEvening { get; set; }

        //Tuesday
        public bool TuesdayMorning { get; set; }
        public bool TuesdayAfternoon { get; set; }
        public bool TuesdayEvening { get; set; }

        //Wednesday
        public bool WednesdayMorning { get; set; }
        public bool WednesdayAfternoon { get; set; }
        public bool WednesdayEvening { get; set; }

        //Thursday
        public bool ThursdayMorning { get; set; }
        public bool ThursdayAfternoon { get; set; }
        public bool ThursdayEvening { get; set; }

        //Friday
        public bool FridayMorning { get; set; }
        public bool FridayAfternoon { get; set; }
        public bool FridayEvening { get; set; }

        //Saturday
        public bool SaturdayMorning { get; set; }
        public bool SaturdayAfternoon { get; set; }
        public bool SaturdayEvening { get; set; }

        //Sunday
        public bool SundayMorning { get; set; }
        public bool SundayAfternoon { get; set; }
        public bool SundayEvening { get; set; }
    }
}
