using System;
using System.ComponentModel.DataAnnotations;

namespace SeniorCollegeScheduler.Models.ViewModels
{
    public class CreateClassCommand
    {
        //Still need preferred time variables
        //NEED DATA ANOTATIONS
        [Required]
        [StringLength(45)]
        public string ProposedTitle { get; set; }
        [Range(1,99)]
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
        public string OtherEquipmentNeeded { get; set; }
        public double HandoutCost { get; set; }
        public string StipendRequested { get; set; }


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
                

            };
        }
    }
}

