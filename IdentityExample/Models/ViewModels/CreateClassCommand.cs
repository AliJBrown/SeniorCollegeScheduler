using System;
using System.ComponentModel.DataAnnotations;

namespace SeniorCollegeScheduler.Models.ViewModels
{
    public class CreateClassCommand
    {
        //NEED DATA ANOTATIONS
        [Required]
        [StringLength(45)]
        public string ProposedTitle { get; set; }

        [Range(1, 99)]
        public int NumClassSessions { get; set; }

        [Range(1, 999)]
        public int LengthOfSession { get; set; }

        [Required]
        public string ClassDesc { get; set; }

        [Required]
        public string PreRequisites { get; set; }

        [Range(1, 999)]
        public int MinStudentCount { get; set; }

        [Range(1, 999)]
        public int MaxStudentCount { get; set; }

        [Range(1, 999)]
        public int TablesNeeded { get; set; }

        [Range(1, 999)]
        public int ChairsNeeded { get; set; }

        public double HandoutCost { get; set; }
        public string StipendRequested { get; set; }

        //Prefered Times Variables

        public string DateTimeRestrictions { get; set; }

        //Monday
        public string MondayMorning { get; set; }
        public string MondayAfternoon { get; set; }
        public string MondayEvening { get; set; }

        //Tuesday
        public string TuesdayMorning { get; set; }
        public string TuesdayAfternoon { get; set; }
        public string TuesdayEvening { get; set; }

        //Wednesday
        public string WednesdayMorning { get; set; }
        public string WednesdayAfternoon { get; set; }
        public string WednesdayEvening { get; set; }

        //Thursday
        public string ThursdayMorning { get; set; }
        public string ThursdayAfternoon { get; set; }
        public string ThursdayEvening { get; set; }

        //Friday
        public string FridayMorning { get; set; }
        public string FridayAfternoon { get; set; }
        public string FridayEvening { get; set; }

        //Saturday
        public string SaturdayMorning { get; set; }
        public string SaturdayAfternoon { get; set; }
        public string SaturdayEvening { get; set; }

        //Sunday
        public string SundayMorning { get; set; }
        public string SundayAfternoon { get; set; }
        public string SundayEvening { get; set; }

        //Equipment Needed
        public string InternetConnection { get; set; }
        public string DryEraseWithMarkers { get; set; }
        public string ProjectorWithScreen { get; set; }
        public string PCConnectionType { get; set; }
        public string MicrophoneWithSoundSystem { get; set; }
        public string VCROrDVDWithScreen { get; set; }
        public string Podium { get; set; }
        public string OtherEquipmentNeeded { get; set; }

        public ProposedClass ToProposal()
        {
            return new ProposedClass
            {
                ProposedDate = DateTime.Now,
                ProposedTitle = ProposedTitle,
                NumberOfSessions = NumClassSessions,
                LengthOfSession = LengthOfSession,
                CourseDescription = ClassDesc,
                PreRequisite = PreRequisites,
                MinStudentCount = MinStudentCount,
                MaxStudentCount = MaxStudentCount,
                TablesNeeded = TablesNeeded,
                ChairsNeeded = ChairsNeeded,
                OtherEquipmentNeeded = OtherEquipmentNeeded,
                HandoutCost = HandoutCost,
                PCConnectionType = PCConnectionType,
                UnavailableTimes = DateTimeRestrictions
            };
        }
    }
}

