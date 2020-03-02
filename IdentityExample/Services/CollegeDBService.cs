using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SeniorCollegeScheduler.Data;
using SeniorCollegeScheduler.Models;
using SeniorCollegeScheduler.Models.DataModels;
using SeniorCollegeScheduler.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SeniorCollegeScheduler
{
    public class CollegeDBService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<MyIdentityUser> _userManager;

        public CollegeDBService(ApplicationDbContext context, UserManager<MyIdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public int CreateClassProposal(CreateClassCommand cmd, IdentityUser appUser)
        {
            var proposal = cmd.ToProposal();

            proposal.ProposedById = appUser.Id;

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

            if (CheckboxValue == "true")
            {
                value = true;
            }

            return value;
        }

        public ICollection<ClassSummaryViewModel> GetProposals()
        {
            return _context.ProposedClass
                .Where(x => !x.IsReviewed)
                .Select(x => new ClassSummaryViewModel
                {
                    ProposedID = x.ProposedID,
                    ProposedDate = x.ProposedDate,
                    ProposedTitle = x.ProposedTitle,

                    //Two Queries to grab first then last name
                    InstructorName = _context.MyIdentityUser
                    .Where(y => y.InstructorId == x.ProposedById)
                    .Select(y => y.FirstName).SingleOrDefault()
                    + " " + _context.MyIdentityUser
                    .Where(y => y.InstructorId == x.ProposedById)
                    .Select(y => y.LastName).SingleOrDefault(),

                    City = _context.MyIdentityUser
                    .Where(y => y.InstructorId == x.ProposedById)
                    .Select(y => y.City).SingleOrDefault(),

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

                    //Two Queries to grab first then last name
                    InstructorName = _context.MyIdentityUser
                    .Where(y => y.InstructorId == x.ProposedById)
                    .Select(y => y.FirstName).SingleOrDefault()
                    + " " + _context.MyIdentityUser
                    .Where(y => y.InstructorId == x.ProposedById)
                    .Select(y => y.LastName).SingleOrDefault(),

                    City = _context.MyIdentityUser
                    .Where(y => y.InstructorId == x.ProposedById)
                    .Select(y => y.City).SingleOrDefault(),
                })
                .OrderByDescending(x => x.ProposedDate)
                .ToList();
        }

        public void MarkReviewed(int ProposalId)
        {
            var proposal = _context.ProposedClass.Find(ProposalId);
            if (proposal == null) { throw new Exception("Unable to mark proposal reviewed"); }

            proposal.IsReviewed = true;
            _context.SaveChanges();
        }

        public ClassDetailedViewModel GetProposedClassDetails(int id)
        {
            return _context.ProposedClass
                .Where(x => x.ProposedID == id)
                .Select(x => new ClassDetailedViewModel
                {
                    ProposedById = x.ProposedById,
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

        public bool CheckIfFiled(IdentityUser appUser)
        {
            bool IsFiled = _context.MyIdentityUser
                .Where(x => x.InstructorId == appUser.Id)
                .Select(x =>
                    x.IsFiled
                )
                .SingleOrDefault();
            Debug.WriteLine(IsFiled);
            return IsFiled;
        }

        public InstructorDetailsViewModel GetInstructorDetails(IdentityUser appUser)
        {

            return _context.MyIdentityUser
                .Where(x => x.InstructorId.Equals(appUser.Id))
                .Select(x => new InstructorDetailsViewModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    StreetAddress = x.StreetAddress,
                    City = x.City,
                    State = x.State,
                    ZipCode = x.ZipCode,
                    ShareEmail = x.ShareEmail,
                    ShareLandline = x.ShareLandline,
                    ShareMobilePhone = x.ShareMobilePhone,
                    LandlinePhone = x.LandlinePhone,
                    MobilePhone = x.MobilePhone,
                    InstructorBio = x.InstructorBio
                })
                .SingleOrDefault();
        }

        public InstructorDetailsViewModel GetInstructorDetails(string appUser)
        {
            Debug.WriteLine("Calling CORECT METHOD");
            var model = _context.MyIdentityUser
                .Where(x => x.InstructorId.Equals(appUser))
                .Select(x => new InstructorDetailsViewModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    StreetAddress = x.StreetAddress,
                    City = x.City,
                    State = x.State,
                    ZipCode = x.ZipCode,
                    ShareEmail = x.ShareEmail,
                    ShareLandline = x.ShareLandline,
                    ShareMobilePhone = x.ShareMobilePhone,
                    LandlinePhone = x.LandlinePhone,
                    MobilePhone = x.MobilePhone,
                    InstructorBio = x.InstructorBio
                })
                .SingleOrDefault();
            //NEED TO FORMAT PHONE NUMBERS!!!!!!!!!
            //model.LandlinePhone = FormatPhoneNumber(model.LandlinePhone);
            //model.MobilePhone = FormatPhoneNumber(model.MobilePhone);

            return model;
        }

        public void CreateInstructor(CreateInstructorCommand command, IdentityUser user)
        {
            var details = command.ToUser();

            details.InstructorId = user.Id;

            details.ShareMobilePhone = CheckboxValue(command.ShareMobilePhone);
            details.ShareLandline = CheckboxValue(command.ShareLandline);
            details.ShareEmail = CheckboxValue(command.ShareEmail);

            _context.Add(details);
            _context.SaveChanges();
        }

    }
}
