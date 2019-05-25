using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACE_it.Data;
using ACE_it.Helper;
using ACE_it.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
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

        public async Task<IActionResult> Create(int recipeId)
        {
            var user = await _context.AppUsers.FirstAsync(r => r.Email == User.Identity.Name);
            if (user == null)
            {
                //TODO: Redirect to logged out screen
                return null;
            }

            var session = await _context.Sessions.Include(r => r.SessionRecipes)
                .ThenInclude(s => s.Recipe)
                .FirstOrDefaultAsync(r => r.User == user);
            var recipe = _context.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);
            var sessionRecipe = new SessionRecipe() {Recipe = await recipe};
            if (session == null)
            {
                session = new Session {User = user, SessionRecipes = new List<SessionRecipe>(1)};
                session.SessionRecipes.Add(sessionRecipe);
                _context.Sessions.Add(session);
            }
            else
            {
                session.SessionRecipes.Clear();
                session.SessionRecipes.Add(sessionRecipe);
                _context.Sessions.Update(session);
            }

            _context.SaveChanges();
            return RedirectToAction("Show", "SessionRecipe",
                new {sessionId = session.Id, recipeSessionId = sessionRecipe.Id});
        }

        public async Task<IActionResult> Show(int sessionId, int? viewIndex)
        {
            var sessionRecipe = (await _context.Sessions
                .Include(s => s.SessionRecipes)
                .ThenInclude(x => x.Recipe)
                .ThenInclude(x => x.RecipeInstructions)
                .ThenInclude(x => x.Instruction)
                .FirstAsync(s => s.Id == sessionId));

            sessionRecipe.SessionRecipes.Sort((a, b) => a.Order - b.Order);
            var instruction = sessionRecipe.SessionRecipes[sessionRecipe.SessionRecipes.Count - 1];
            var recipe = instruction.Recipe;
            var index = viewIndex.GetValueOrDefault(instruction.Index);

            index = index < recipe.RecipeInstructions.Count ? index : recipe.RecipeInstructions.Count - 1;
            var ri = recipe.RecipeInstructions[index];

            return View(new RecipeSessionViewModel(ri, sessionId, instruction.Index, recipe.RecipeInstructions.Count,
                index, recipe.Id));
        }

        public async Task<IActionResult> Update(int sessionId)
        {
            var session = (await _context.Sessions
                .Include(s => s.SessionRecipes)
                .FirstAsync(s => s.Id == sessionId));
            session.SessionRecipes.Sort((a, b) => a.Order - b.Order);
            session
                .SessionRecipes[session.SessionRecipes.Count - 1]
                .Index++;
            _context.SaveChanges();
            return RedirectToAction("Show", "SessionRecipe", new {sessionId});
        }

        public void Delete(int sessionId)
        {
            var session = (_context.Sessions
                .Include(s => s.SessionRecipes)
                .FirstOrDefault(s => s.Id == sessionId));
            if (session == null) return;
            session.SessionRecipes.Clear();
            _context.Sessions.Update(session);
        }

        public async Task<IActionResult> Finish(int recipeId)
        {
            var user = _context.AppUsers
                .First(r => r.Email == User.Identity.Name);

            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.RecipeInstructions)
                .ThenInclude(ri => ri.Instruction)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.UserCompletedRecipes)
                .Include(r => r.UserReactedToRecipes)
                .FirstOrDefaultAsync(m => m.Id == recipeId);

            var userCompletedRecipe = new UserCompletedRecipe
            {
                RecipeId = recipeId, UserId = user.Id, User = user, Recipe = recipe, Difficulties = "", Comments = null
            };

            _context.Add(userCompletedRecipe);
            _context.SaveChanges();

            return RedirectToAction("Index", "Rate",
                new { RecipeId = recipeId, UserCompletedRecipeId = userCompletedRecipe.Id });
        }
    }
}