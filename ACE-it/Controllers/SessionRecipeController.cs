using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACE_it.Data;
using ACE_it.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var user = await _context.AppUsers.FirstAsync(u => u.Id == User.Identity.Name);
            return View(GetCurrentRecipes(user));
        }

        public async Task<IActionResult> Create(int recipe)
        {
            var user = _context.AppUsers.First(r => r.Email == User.Identity.Name);
            var recipeObj = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == recipe);
            var session = await _context.Sessions.Include(r => r.SessionRecipes)
                .FirstOrDefaultAsync(r => r.User == user);
            if (session == null)
            {
                session = new Session {User = user, SessionRecipes = new List<SessionRecipe>(1)};
                _context.Sessions.Add(session);
            }

            var sessionRecipe = session.SessionRecipes.FirstOrDefault(r => r.Recipe == recipeObj);
            if (sessionRecipe == null)
            {
                sessionRecipe = new SessionRecipe {Recipe = recipeObj};
                session.SessionRecipes.Add(sessionRecipe);
            }

            _context.SaveChanges();
            return RedirectToAction("Show", "SessionRecipe",
                new {sessionId = session.Id, recipeSessionId = sessionRecipe.Id});
        }

        public async Task<IActionResult> Show(int sessionId, int recipeSessionId)
        {
            var sessionRecipe = (await _context.Sessions
                    .Include(s => s.SessionRecipes.Select(x => x.Recipe))
                    .FirstAsync(s => s.Id == sessionId))
                .SessionRecipes.First(a => a.Id == recipeSessionId);
            return View(sessionRecipe);
        }

        private async Task<List<Recipe>> GetCurrentRecipes(
            User user)
        {
            return (await _context.Sessions.FindAsync(new {user}))
                .SessionRecipes.ConvertAll(s => s.Recipe);
        }
    }
}