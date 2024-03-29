using System;
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
    public class RateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RateController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? recipeId, bool? reviewSent, int userCompletedRecipeId)
        {
            if (recipeId == null) return NotFound();

            var recipe = await _context.Recipes
                .Include(r => r.UserCompletedRecipes)
                .Include(r => r.UserReactedToRecipes)
                .FirstOrDefaultAsync(m => m.Id == recipeId);
            if (recipe == null) return NotFound();

            var user = await _context.AppUsers
                .FirstAsync(r => r.Email == User.Identity.Name);

            var userCompletedRecipe = _context.UserCompletedRecipes.FindAsync(userCompletedRecipeId);

            return View(new RateViewModel(user, recipe, reviewSent != null, await userCompletedRecipe));
        }

        public async Task<IActionResult> React(int recipeId, string userId, string reaction, int userCompletedRecipeId)
        {
            var react = Reaction.Like;

            switch (reaction)
            {
                case "love":
                {
                    react = Reaction.Love;
                    break;
                }
                case "dislike":
                {
                    react = Reaction.Dislike;
                    break;
                }
            }

            var userReactedToRecipe = new UserReactedToRecipe
            {
                UserId = userId, RecipeId = recipeId, Reaction = react
            };

            var oldUserReaction = await _context.UserReactedToRecipes.FindAsync(userId, recipeId);

            //if user wants to remove the reaction
            if (oldUserReaction != null && (oldUserReaction.Reaction == userReactedToRecipe.Reaction))
            {
                _context.Remove(oldUserReaction);
            }
            //if user wants to update an old reaction to a new one
            else if(oldUserReaction != null)
            {
                _context.Remove(oldUserReaction);
                _context.Add(userReactedToRecipe);
            }
            //if user wants to just add a new reaction
            else
            {
                _context.Add(userReactedToRecipe);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Rate", new { RecipeId = recipeId, UserCompletedRecipeId = userCompletedRecipeId });
        }

        public async Task<IActionResult> Comment(int recipeId, string userId, string commentary, int userCompletedRecipeId)
        {
            var userCompletedRecipe = await _context.UserCompletedRecipes.FindAsync(userCompletedRecipeId);

            if(userCompletedRecipe.Comments == null){
                userCompletedRecipe.Comments = new List<Comment>();
            }

            var comment = new Comment
            {
                UserCompletedRecipe = userCompletedRecipe, Text = commentary == null ? "" : commentary
            };

            userCompletedRecipe.Comments.Add(comment);

            _context.Update(userCompletedRecipe);
            _context.SaveChanges();

            return RedirectToAction("Index", "Rate",
                new { RecipeId = recipeId, UserCompletedRecipeId = userCompletedRecipeId, ReviewSent = true });
        }

        public async Task<IActionResult> Difficulties(int recipeId, String userId, String difficulties, int userCompletedRecipeId)
        {
            var userCompletedRecipe = await _context.UserCompletedRecipes.FindAsync(userCompletedRecipeId);

            userCompletedRecipe.Difficulties = difficulties == null ? "" : difficulties;

            _context.Update(userCompletedRecipe);
            _context.SaveChanges();

            return RedirectToAction("Index", "Rate",
                new { RecipeId = recipeId, UserCompletedRecipeId = userCompletedRecipeId, ReviewSent = true });
        }
    }
}
