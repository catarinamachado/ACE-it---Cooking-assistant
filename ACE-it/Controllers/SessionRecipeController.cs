using System.Collections.Generic;
using System.Threading.Tasks;
using ACE_it.Data;
using ACE_it.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace ACE_it.Controllers
{
    public class SessionRecipeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public SessionRecipeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
            var user = await _context.AppUsers.FindAsync(userId);
            return View(GetCurrentRecipes(user));
        }

        public async Task<IActionResult> Create(int recipe)
        {
            var userId = (await _userManager.GetUserAsync(HttpContext.User)).Id;
            var user = await _context.AppUsers.FindAsync(userId);
            var recipeObj = await _context.Recipes.FindAsync(recipe);
            var newRecipe = new SessionRecipe {Recipe = recipeObj};
            var session = _context.Sessions.FindAsync(user);
            session.Result.SessionRecipes.Add(newRecipe);
            return RedirectToAction("Show");
        }

        public async Task<IActionResult> Show(int id)
        {
            var sessionRecipe = await _context.Sessions.FindAsync(HttpContext.User);
            return View(sessionRecipe.SessionRecipes.Find(a => a.Id == id));
        }

        private async Task<List<Recipe>> GetCurrentRecipes(
            User user)
        {
            return (await _context.Sessions.FindAsync(new {user}))
                .SessionRecipes.ConvertAll(s => s.Recipe);
        }
    }
}