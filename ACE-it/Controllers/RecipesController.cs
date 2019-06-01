using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACE_it.Data;
using ACE_it.Helper;
using ACE_it.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACE_it.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index(
            string searchString, int? category,
            string time, Difficulty? difficulty, string likes)
        {
            var recipes = GetRecipes(
                searchString, time, difficulty, likes, category);
            var categories = _context.Categories.ToListAsync();

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentCategory"] = category.GetValueOrDefault(-1);
            ViewData["CurrentTime"] = time == null ? "none" : time;
            ViewData["CurrentDifficulty"] = difficulty.HasValue
                ? difficulty.ToString()
                : "";
            ViewData["CurrentLikes"] = likes == null ? "none" : likes;

            return View(new RecipeViewModel(await recipes, await categories));
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.RecipeInstructions)
                .ThenInclude(ri => ri.Instruction)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.UserCompletedRecipes)
                .Include(r => r.UserReactedToRecipes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null) return NotFound();

            var user = await _context.AppUsers.FirstOrDefaultAsync(r => r.Email == User.Identity.Name);

            var session = await _context.Sessions
                .Include(r => r.SessionRecipes)
                .ThenInclude(s => s.Recipe)
                .FirstOrDefaultAsync(s => s.User == user && s.SessionRecipes.Any(r => r.Recipe == recipe));

            var comments = await _context.Comments
                .Where(c => c.UserCompletedRecipe.Recipe.Id == id)
                .Include(c => c.UserCompletedRecipe)
                .ThenInclude(ci => ci.User)
                .ToListAsync();

            var difficulties = recipe.UserCompletedRecipes
                .Where(u => u.UserId == user.Id)
                .Select(i => i.Difficulties).ToList();

            return View(session != null
                ? new RecipeDetailsViewModel(recipe, session.Id, comments, user.Id, difficulties)
                : new RecipeDetailsViewModel(recipe, null, comments, user.Id, difficulties));
        }

        // PRIVATE

        private async Task<List<Recipe>> GetRecipes(
            string searchString, string time, Difficulty? difficulty,
            string likes, int? category)
        {
            var query =
                from recipe in _context.Recipes
                join recipeIngredients in _context.RecipeIngredients
                    on recipe.Id equals recipeIngredients.RecipeId
                join ingredient in _context.Ingredients
                    on recipeIngredients.IngredientId equals ingredient.Id
                where (NameContains(recipe.Name, searchString)
                       || NameContains(ingredient.Name, searchString)) &&
                      RecipeTimeBetween(recipe.DefaultDuration, time) &&
                      RecipeDifficultyIs(recipe.Difficulty, difficulty) &&
                      CategoryIsCategory(recipe.Category, category) &&
                      RecipeLikesBetween(
                          (from ucr in _context.UserReactedToRecipes
                              where ucr.Recipe.Id == recipe.Id && ucr.Reaction == Reaction.Like
                              select ucr).Count(), likes)
                select recipeIngredients;

            var listRecipeIds = new List<int>();
            foreach (var item in await query.ToListAsync())
            {
                listRecipeIds.Add(item.RecipeId);
            }

            return await _context.Recipes
                .Where(r => listRecipeIds.Contains(r.Id))
                .Include(r => r.UserCompletedRecipes)
                .Include(r => r.UserReactedToRecipes)
                .ToListAsync();
        }
    
        private static bool NameContains(string name, string searchString)
        {
            return searchString == null || name.ToLower().Contains(searchString.Trim().ToLower());
        }

        private static bool RecipeTimeBetween(int duration, string time)
        {
            if (time == null) return true;

            switch (time)
            {
                case "very-short":
                    return duration < 600;
                case "short":
                    return duration >= 600 && duration < 1200;
                case "medium-short":
                    return duration >= 1200 && duration < 1800;
                case "medium":
                    return duration >= 1800 && duration < 2700;
                case "medium-long":
                    return duration >= 2700 && duration < 3600;
                default:
                    return duration >= 3600;
            }
        }

        private static bool RecipeDifficultyIs(
            Difficulty recipeDifficulty, Difficulty? requestedDifficulty)
        {
            return !requestedDifficulty.HasValue || recipeDifficulty == requestedDifficulty;
        }

        private static bool CategoryIsCategory(Category rc, int? category)
        {
            return !category.HasValue || rc.Id == category;
        }

        private static bool RecipeLikesBetween(int countLikes, string likes)
        {
            if (likes == null) return true;

            switch (likes)
            {
                case "few":
                    return countLikes >= 100;
                case "some":
                    return countLikes >= 500;
                default:
                    return countLikes >= 1000;
            }
        }
    }
}