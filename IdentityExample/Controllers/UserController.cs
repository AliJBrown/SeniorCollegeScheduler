using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeniorCollegeScheduler.Models.ViewModels;

namespace SeniorCollegeScheduler.Controllers
{
    public class UserController : Controller
    {
        private readonly CollegeDBService _service;
        private readonly UserManager<IdentityUser> _userService;

        public UserController(CollegeDBService service, UserManager<IdentityUser> userService)
        {
            _service = service;
            _userService = userService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(new CreateInstructorCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateInstructorCommand command)
        {
            var appUser = await _userService.GetUserAsync(User);
            bool HasFiled = _service.CheckIfFiled(appUser);
            try
            {
                if (ModelState.IsValid)
                {
                    if (HasFiled)
                    {
                        //TODO NEED TO CHANGE THIS TO INFORM USER THAT THEY HAVE MADE A PROPOSAL ALREADY
                        return RedirectToAction(nameof(ViewInstructorDetails));
                    }
                    else
                    {
                        Debug.WriteLine("SAVING INSTRUCTOR CREATION");
                        _service.CreateInstructor(command, appUser);
                        return RedirectToAction(nameof(ProposalSuccess));
                    }
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

        public IActionResult ProposalSuccess()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> ViewInstructorDetails()
        {
            var appUser = await _userService.GetUserAsync(User);

            if (_service.CheckIfFiled(appUser))
            {
                var model = _service.GetInstructorDetails(appUser);

                if (model == null)
                {
                    return NotFound();
                }

                return View(model);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
        
        
        public IActionResult ViewProposedInstructorDetails(string id)
        {
            Debug.WriteLine("calling instructor details");
            var model = _service.GetInstructorDetails(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
            
        }
    }
}