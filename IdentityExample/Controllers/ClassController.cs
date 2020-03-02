using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeniorCollegeScheduler.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace SeniorCollegeScheduler.Controllers
{
    public class ClassController : Controller
    {
        private readonly CollegeDBService _service;
        private readonly UserManager<IdentityUser> _userService;

        public ClassController(CollegeDBService service, UserManager<IdentityUser> userService)
        {
            _service = service;
            _userService = userService;
        }

        [Authorize]
        public async Task<IActionResult> CreateProposal()
        {
            var appUser = await _userService.GetUserAsync(User);
            bool HasFiled = _service.CheckIfFiled(appUser);
            if (HasFiled)
            {
                return View(new CreateClassCommand());
            }
            return RedirectToAction(nameof(UserInformationNeeded));
        }

        public IActionResult UserInformationNeeded()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProposal(CreateClassCommand command)
        {
            var appUser = await _userService.GetUserAsync(User);
            try
            {
                if (ModelState.IsValid)
                {
                    var id = _service.CreateClassProposal(command, appUser);
                    return RedirectToAction(nameof(ProposedClassDetails), new { id = id });
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An error occurred saving the proposal"
                    );
            }

            return View(command);
        }

        [HttpPost]
        public IActionResult MarkProposalReviewed(int id)
        {
            _service.MarkReviewed(id);
            return RedirectToAction(nameof(ProposedClassesOverview));
        }

        [Authorize]
        public async Task<IActionResult> ProposedClassesOverview()
        {
            var appUser = await _userService.GetUserAsync(User);
            var models = _service.GetProposals();
            return View(models);
        }

        [Authorize(Roles = "Admin")]
        //[Authorize]
        public IActionResult ReviewedClassesOverview()
        {
            var models = _service.GetReviewedProposals();
            return View(models);
        }

        [Authorize]
        public IActionResult ProposedClassDetails(int id)
        {
            var model = _service.GetProposedClassDetails(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}