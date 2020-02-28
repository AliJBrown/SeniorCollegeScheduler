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
        private readonly UserManager<IdentityUser> _userManager;

        public CollegeDBService(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public int CreateClassProposal(CreateClassCommand cmd)
        {
            var proposal = cmd.ToProposal();

            

            proposal.StipendRequested = CheckboxValue(cmd.StipendRequested);

            //Checks equipment checkboxes
            proposal.InternetConnection = CheckboxValue(cmd.InternetConnection);
            proposal.DryEraseBoard = CheckboxValue(cmd.DryEraseWithMarkers);
            proposal.ProjectorWithScreen = CheckboxValue(cmd.ProjectorWithScreen);
            proposal.MicrophoneAndSound = CheckboxValue(cmd.MicrophoneWithSoundSystem);
            proposal.DVDAndVCRPlayer = CheckboxValue(cmd.VCROrDVDWithScreen);
            proposal.Podium = CheckboxValue(cmd.Podium);

            //Prefered Times Checkboxes being checked
            //Monday
            proposal.MondayMorning = CheckboxValue(cmd.MondayMorning);
            proposal.MondayAfternoon = CheckboxValue(cmd.MondayAfternoon);
            proposal.MondayEvening = CheckboxValue(cmd.MondayEvening);

            //Tuesday
            proposal.TuesdayMorning = CheckboxValue(cmd.TuesdayMorning);
            proposal.TuesdayAfternoon = CheckboxValue(cmd.TuesdayAfternoon);
            proposal.TuesdayEvening = CheckboxValue(cmd.TuesdayEvening);

            //Wednesday
            proposal.WednesdayMorning = CheckboxValue(cmd.WednesdayMorning);
            proposal.WednesdayAfternoon = CheckboxValue(cmd.WednesdayAfternoon);
            proposal.WednesdayEvening = CheckboxValue(cmd.WednesdayEvening);

            //Thursday
            proposal.ThursdayMorning = CheckboxValue(cmd.ThursdayMorning);
            proposal.ThursdayAfternoon = CheckboxValue(cmd.ThursdayAfternoon);
            proposal.ThursdayEvening = CheckboxValue(cmd.ThursdayEvening);

            //Friday
            proposal.FridayMorning = CheckboxValue(cmd.FridayMorning);
            proposal.FridayAfternoon = CheckboxValue(cmd.FridayAfternoon);
            proposal.FridayEvening = CheckboxValue(cmd.FridayEvening);

            //Saturday
            proposal.SaturdayMorning = CheckboxValue(cmd.SaturdayMorning);
            proposal.SaturdayAfternoon = CheckboxValue(cmd.SaturdayAfternoon);
            proposal.SaturdayEvening = CheckboxValue(cmd.SaturdayEvening);

            //Saturday
            proposal.SundayMorning = CheckboxValue(cmd.SundayMorning);
            proposal.SundayAfternoon = CheckboxValue(cmd.SundayAfternoon);
            proposal.SundayEvening = CheckboxValue(cmd.SundayEvening);

            _context.Add(proposal);
            _context.SaveChanges();
            return proposal.ProposedID;
        }

        //Checks the value the checkbox returns and sees if its true or false
        public bool CheckboxValue(string CheckboxValue)
        {
            bool value = false;

            if(CheckboxValue == "true")
            {
                value = true;
            }

            return value;
        }

        public ICollection<ClassSummaryViewModel> GetProposals(IdentityUser user)
        {
            return _context.ProposedClass
                .Where(x => !x.IsReviewed)
                .Select(x => new ClassSummaryViewModel
                {
                    ProposedID = x.ProposedID,
                    ProposedDate = x.ProposedDate,
                    ProposedTitle = x.ProposedTitle,
                    user = user.Id
                })
                .OrderByDescending(x => x.ProposedDate)
                .ToList();
        }
        public ICollection<ClassSummaryViewModel> GetReviewedProposals()
        {
            return _context.ProposedClass
                .Where(x => x.IsReviewed)
                .Select(x => new ClassSummaryViewModel
                {
                    ProposedID = x.ProposedID,
                    ProposedDate = x.ProposedDate,
                    ProposedTitle = x.ProposedTitle,
                    
                })
                .OrderByDescending(x => x.ProposedDate)
                .ToList();
        }

        public void MarkReviewed(int ProposalId)
        {
            var proposal = _context.ProposedClass.Find(ProposalId);
            if(proposal == null) { throw new Exception("Unable to mark proposal reviewed"); }

            proposal.IsReviewed = true;
            _context.SaveChanges();
        }

        public ClassDetailedViewModel GetProposedClassDetails(int id)
        {
            return _context.ProposedClass
                .Where(x => x.ProposedID == id)
                .Select(x => new ClassDetailedViewModel
                {
                    ProposedDate = x.ProposedDate,
                    ProposedTitle = x.ProposedTitle,
                    ProposalId = x.ProposedID,
                    IsReviewed = x.IsReviewed,
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
                    HandoutCost = x.HandoutCost,
                    InternetConnection = x.InternetConnection,
                    DryEraseWithMarkers = x.DryEraseBoard,
                    ProjectorWithScreen = x.ProjectorWithScreen,
                    PCConnectionType = x.PCConnectionType,
                    MicrophoneWithSoundSystem = x.MicrophoneAndSound,
                    VCROrDVDWithScreen = x.DVDAndVCRPlayer,
                    Podium = x.Podium,
                    DateTimeRestrictions = x.UnavailableTimes,
                    MondayMorning = x.MondayMorning,
                    MondayAfternoon = x.MondayAfternoon,
                    MondayEvening = x.MondayEvening,
                    TuesdayMorning = x.TuesdayMorning,
                    TuesdayAfternoon = x.TuesdayAfternoon,
                    TuesdayEvening = x.TuesdayEvening,
                    WednesdayMorning = x.WednesdayMorning,
                    WednesdayAfternoon = x.WednesdayAfternoon,
                    WednesdayEvening = x.WednesdayEvening,
                    ThursdayMorning = x.ThursdayMorning,
                    ThursdayAfternoon = x.ThursdayAfternoon,
                    ThursdayEvening = x.ThursdayEvening,
                    FridayMorning = x.FridayMorning,
                    FridayAfternoon = x.FridayAfternoon,
                    FridayEvening = x.FridayEvening,
                    SaturdayMorning = x.SaturdayMorning,
                    SaturdayAfternoon = x.SaturdayAfternoon, 
                    SaturdayEvening = x.SaturdayEvening,
                    SundayMorning = x.SundayMorning,
                    SundayAfternoon = x.SundayAfternoon,
                    SundayEvening = x.SundayEvening

                    
                })
                .SingleOrDefault();
        }
    }
}
