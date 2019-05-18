using Microsoft.AspNetCore.Mvc;

namespace ACE_it.Controllers
{
    public class PlanningController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}