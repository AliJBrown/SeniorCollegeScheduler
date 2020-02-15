using Microsoft.AspNetCore.Mvc;

namespace SeniorCollegeScheduler.Controllers
{
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProposedClassesOverview()
        {
            return View();
        }

        public IActionResult ProposedClassDetailed()
        {
            return View();
        }
    }
}