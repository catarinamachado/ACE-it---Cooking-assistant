using System;
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

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null) return NotFound();

            var recipe = await _context.Recipes
                .Include(r => r.UserCompletedRecipes)
                .Include(r => r.UserReactedToRecipes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null) return NotFound();
            
            var user = _context.AppUsers
                .First(r => r.Email == User.Identity.Name);
            
            return View(new RateViewModel(
                user, recipe));
        }

        public async Task<IActionResult> React(int id, String userId, String reaction)
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
                UserId = userId, RecipeId = id, Reaction = react
            };
            
            var oldUserReaction = _context.UserReactedToRecipes.Find(userId, id);
            
            if(oldUserReaction != null)
            {
                _context.Remove(oldUserReaction);
            }
                
            _context.Add(userReactedToRecipe);
            _context.SaveChanges();   
            
            return RedirectToAction("Index", "Rate", new { id });
        }
    }
}
