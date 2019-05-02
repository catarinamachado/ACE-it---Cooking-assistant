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
            var recipeObj = await _context.Recipes.FindAsync(recipe);
            var session = _context.Sessions.FirstOrDefault(r => r.User == user);
            if (session == null)
            {
                session = new Session {User = user, SessionRecipes = new List<SessionRecipe>(1)};
                _context.Sessions.Add(session);
            }
            var recipeSession = session.SessionRecipes.FirstOrDefault(r => r.Recipe == recipeObj) ??
                                new SessionRecipe {Recipe = recipeObj};
            return RedirectToAction("Show", "SessionRecipe",
                new {sessionId = session.Id, recipeSessionId = recipeSession.Id});
        }

        public async Task<IActionResult> Show(int sessionId, int recipeSessionId)
        {
            await _context.Sessions.ForEachAsync(r => Console.WriteLine(r.ToString()));
            var session = await _context.Sessions.FirstAsync(s => s.Id == sessionId);
            return View(session.SessionRecipes.First(a => a.Id == recipeSessionId));
        }

        private async Task<List<Recipe>> GetCurrentRecipes(
            User user)
        {
            return (await _context.Sessions.FindAsync(new {user}))
                .SessionRecipes.ConvertAll(s => s.Recipe);
        }
    }
}