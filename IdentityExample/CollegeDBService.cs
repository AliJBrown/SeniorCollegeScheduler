using Microsoft.AspNetCore.Identity;
using SeniorCollegeScheduler.Data;
using SeniorCollegeScheduler.Models;
using SeniorCollegeScheduler.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SeniorCollegeScheduler
{
    public class CollegeDBService
    {
        private readonly ApplicationDbContext _context;
        

        public CollegeDBService(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public int CreateClassProposal(CreateClassCommand cmd)
        {
            var proposal = cmd.ToProposal();

            Debug.WriteLine(cmd.StipendRequested);

            if (cmd.StipendRequested == "true")
            {
                proposal.StipendRequested = true;
            }
            else
                proposal.StipendRequested = false;
            

            _context.Add(proposal);
            _context.SaveChanges();
            return proposal.ProposedID;
        }

        public ICollection<ClassSummaryViewModel> GetProposals()
        {
            return _context.ProposedClass
                .Select(x => new ClassSummaryViewModel
                {
                    ProposedID = x.ProposedID,
                    ProposedDate = x.ProposedDate,
                    ProposedTitle = x.ProposedTitle
                })
                .ToList();
        }

        public ClassDetailedViewModel GetProposedClassDetails(int id)
        {
            return _context.ProposedClass
                .Where(x => x.ProposedID == id)
                .Select(x => new ClassDetailedViewModel
                {
                    ProposedDate = x.ProposedDate,
                    ProposedTitle = x.ProposedTitle,
                    NumClassSessions = x.NumberOfSessions,
                    LengthOfSession = x.LengthOfSession,
                    ClassDesc = x.CourseDescription,
                    PreRequisites = x.PreRequisite,
                    MinStudentCount = x.MinStudentCount,
                    MaxStudentCount = x.MaxStudentCount,
                    TablesNeeded = x.TablesNeeded,
                    ChairsNeeded = x.ChairsNeeded,
                    StipendRequested = x.StipendRequested,
                    OtherEquipmentNeeded = x.OtherEquipmentNeeded,
                    HandoutCost = x.HandoutCost
                })
                .SingleOrDefault();
        }
    }
}
