using System;

namespace SeniorCollegeScheduler.Models
{
    public class ClassSummaryViewModel
    {
        public int ProposedID { get; set; }
        public DateTime ProposedDate { get; set; }
        public string ProposedTitle { get; set; }
        public string InstructorName { get; set; }
        public string City { get; set; }
        

        public static ClassSummaryViewModel FromProposedClass(ProposedClass proposedClass)
        {
            return new ClassSummaryViewModel
            {
                ProposedID = proposedClass.ProposedID,
                ProposedDate = proposedClass.ProposedDate,
                ProposedTitle = proposedClass.ProposedTitle,
                
            };
        }
    }
}
