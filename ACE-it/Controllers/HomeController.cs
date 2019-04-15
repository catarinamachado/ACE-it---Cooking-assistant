using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ACE_it.Data;
using ACE_it.Helper;
using ACE_it.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACE_it.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? n)
        {
            if (!User.Identity.IsAuthenticated) return View();

            var user = _context.AppUsers
                .First(r => r.Email == User.Identity.Name);

            var list = _context.UserCompletedRecipes
                .Where(ucr => ucr.User.Id == user.Id)
                .GroupBy(ucr => ucr.RecipeId)
                .OrderByDescending(u => u.Count())
                .Take(n.HasValue && n.Value <= 9 ? n.Value : 3);

            await list.ForEachAsync(l =>
                    l.ElementAt(0).Recipe = _context.Recipes
                        .Where(r => r.Id == l.Key)
                        .Include(r => r.RecipeIngredients)
                        .First()
            );

            return View(new DashboardViewModel(user, await list.ToListAsync()));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
