using System;

namespace SeniorCollegeScheduler.Models.ViewModels
{
    public class CreateClassCommand
    {
        //Still need preferred time variables
        //NEED DATA ANOTATIONS
        public DateTime TodaysDate { get; set; }
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

