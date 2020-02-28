using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeniorCollegeScheduler.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace SeniorCollegeScheduler.Controllers
{
    public class ClassController : Controller
    {

        private readonly CollegeDBService _service;

        public ClassController(CollegeDBService service)
        {
            _service = service;
        }

        [Authorize]
        public IActionResult CreateProposal()
        {
            return View(new CreateClassCommand());
        }

        [HttpPost]
        public IActionResult CreateProposal(CreateClassCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var id = _service.CreateClassProposal(command);
                    return RedirectToAction(nameof(ProposedClassDetails), new { id = id });
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the proposal"
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
        public IActionResult ProposedClassesOverview()
        {
            var models = _service.GetProposals();
            return View(models);
        }

        [Authorize]
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