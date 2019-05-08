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

        public async Task<IActionResult> Index(int? recipeId, bool? reviewSent)
        {
            if (recipeId == null) return NotFound();

            var recipe = await _context.Recipes
                .Include(r => r.UserCompletedRecipes)
                .Include(r => r.UserReactedToRecipes)
                .FirstOrDefaultAsync(m => m.Id == recipeId);
            if (recipe == null) return NotFound();
            
            var user = _context.AppUsers
                .First(r => r.Email == User.Identity.Name);
            
            return View(new RateViewModel(
                user, recipe, reviewSent != null));
        }

        public async Task<IActionResult> React(int recipeId, String userId, String reaction)
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
            
            var oldUserReaction = _context.UserReactedToRecipes.Find(userId, recipeId);
            
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

            return RedirectToAction("Index", "Rate", new { recipeId });
        }

        
        //MISSING ID COMPLETED RECIPE
        public async Task<IActionResult> Comment(int recipeId, String userId, String commentary)
        {
            var idCompleted = 1; //é suposto a função receber esta variável como parâmetro

            var userCompletedRecipe = _context.UserCompletedRecipes.Find(idCompleted);
            
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
            
            return RedirectToAction("Index", "Rate", new { RecipeId = recipeId, ReviewSent = true });
        }
        
        //MISSING ID COMPLETED RECIPE
        public async Task<IActionResult> Difficulties(int recipeId, String userId, String difficulties)
        {
            var idCompleted = 1; //é suposto a função receber esta variável como parâmetro

            var userCompletedRecipe = _context.UserCompletedRecipes.Find(idCompleted);

            userCompletedRecipe.Difficulties = difficulties == null ? "" : difficulties;
            
            _context.Update(userCompletedRecipe);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Rate", new { RecipeId = recipeId, ReviewSent = true });
        }
    }
}
