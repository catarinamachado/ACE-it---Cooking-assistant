using System.Collections.Generic;
using System.Threading.Tasks;
using ACE_it.Data;
using ACE_it.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACE_it.Controllers
{
    public class SessionRecipeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SessionRecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.User;
            var user = await _context.AppUsers.FindAsync(userId);
            return View(GetCurrentRecipes(user));
        }

        public async Task<IActionResult> Create(int recipe)
        {
            var userId = HttpContext.User;
            var user = await _context.AppUsers.FindAsync("1");
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