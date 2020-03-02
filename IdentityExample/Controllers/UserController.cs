using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeniorCollegeScheduler.Models.DataModels;
using SeniorCollegeScheduler.Models.ViewModels;

namespace SeniorCollegeScheduler.Controllers
{
    public class UserController : Controller
    {
        private readonly CollegeDBService _service;
        private readonly UserManager<MyIdentityUser> userManager;
        private readonly SignInManager<MyIdentityUser> signInManager;
        private readonly RoleManager<UserRole> roleManager;

        public UserController(CollegeDBService service, UserManager<MyIdentityUser> userManager,
            SignInManager<MyIdentityUser> signInManager, RoleManager<UserRole> roleManager)
        {
            _service = service;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(new CreateInstructorCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateInstructorCommand command)
        {
            //var appUser = await _userService.GetUserAsync(User);
            var appUser = await userManager.GetUserAsync(User);
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
            //var appUser = await _userService.GetUserAsync(User);
            var appUser = await userManager.GetUserAsync(User);

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

        //[Authorize(Policy = "IsAdmin")]
        [Authorize]
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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser user = new MyIdentityUser();
                user.UserName = obj.UserName;
                user.Email = obj.Email;

                IdentityResult result = userManager.CreateAsync
                    (user, obj.Password).Result;

                if (result.Succeeded)
                {
                    if (!roleManager.RoleExistsAsync("NormalUser").Result)
                    {
                        UserRole role = new UserRole();
                        role.Name = "NormalUser";
                        role.Description = "Perform normal instructor operations";
                        IdentityResult roleResult = roleManager.
                            CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("",
                                "Error Creating Role!");
                            return View(obj);
                        }
                    }

                    userManager.AddToRoleAsync(user, "NormalUser").Wait();
                    return RedirectToAction("Login", "Account");
                }
            }

            return View(obj);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync
                    (obj.UserName, obj.Password, obj.RememberMe, false).Result;

                if (result.Succeeded)
                {

                    //add if statement here to same Role to Claim

                    MyIdentityUser user = userManager.GetUserAsync(HttpContext.User).Result;
                    if (userManager.IsInRoleAsync(user, "NormalUser").Result)
                    {
                        Debug.WriteLine("User role is \"NormalUser\".");
                    }
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login!");
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login", "Account");
        }
    }
}