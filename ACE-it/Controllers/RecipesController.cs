using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            int? time, Difficulty? difficulty, int? likes)
        {
            var recipes = GetRecipes(
                searchString, time, difficulty, likes, category);
            var categories = _context.Categories.ToListAsync();

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentCategory"] = category.GetValueOrDefault(-1);
            ViewData["CurrentTime"] = time.GetValueOrDefault(-1);
            ViewData["CurrentDifficulty"] = difficulty.HasValue
                ? difficulty.ToString() : "";
            ViewData["CurrentLikes"] = likes.GetValueOrDefault(-1);

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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null) return NotFound();

            Console.WriteLine(recipe.RecipeIngredients.Count);
            return View(recipe);
        }

        // PRIVATE

        private async Task<List<Recipe>> GetRecipes(
            string searchString, int? time, Difficulty? difficulty,
            int? likes, int? category)
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
                          (from ucr in _context.UserCompletedRecipes
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
                .ToListAsync();
        }

        private static bool NameContains(string name, string searchString)
        {
            return searchString == null ? true :
                   name.ToLower().Contains(searchString.Trim().ToLower());
        }

        private static bool RecipeTimeBetween(int duration, int? time)
        {
            if (!time.HasValue) return true;

            switch (time)
            {
                case 0:
                    return duration < 10*60;
                case 10:
                    return duration >= 10*60 && duration < 20*60;
                case 20:
                    return duration >= 20*60 && duration < 30*60;
                case 30:
                    return duration >= 30*60 && duration < 45*60;
                case 45:
                    return duration >= 45*60 && duration < 60*60;
                default:
                    return duration >= 60*60;
            }
        }

        private static bool RecipeDifficultyIs(
            Difficulty recipeDifficulty, Difficulty? requestedDifficulty)
        {
            return requestedDifficulty.HasValue ? recipeDifficulty == requestedDifficulty : true;
        }

        private static bool CategoryIsCategory(Category rc, int? category)
        {
            return category.HasValue ? rc.Id == category : true;
        }

        private bool RecipeLikesBetween(int countLikes, int? likes)
        {
            if (!likes.HasValue) return true;

            switch (likes)
            {
                case 100:
                    return countLikes >= 100;
                case 500:
                    return countLikes >= 500;
                default:
                    return countLikes >= 1000;
            }
        }
    }
}
