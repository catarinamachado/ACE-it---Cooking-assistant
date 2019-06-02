using Microsoft.AspNetCore.Mvc;

namespace ACE_it.Controllers
{
    public class HelpPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
