using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_College_Project.Models.ViewModels
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
                InstructorName = proposedClass.ProposedByInstructor,
                City = proposedClass.City
            };
        }
    }
}
