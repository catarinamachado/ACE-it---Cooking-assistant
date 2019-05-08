using System;
using System.Drawing;
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

        public async Task<IActionResult> Index(int? id, bool? commentSent)
        {
            if (id == null) return NotFound();
            if (commentSent == null) commentSent = false;

            var recipe = await _context.Recipes
                .Include(r => r.UserCompletedRecipes)
                .Include(r => r.UserReactedToRecipes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null) return NotFound();
            
            var user = _context.AppUsers
                .First(r => r.Email == User.Identity.Name);
            
            return View(new RateViewModel(
                user, recipe, (bool) commentSent));
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

            return RedirectToAction("Index", "Rate", new { id });
        }

        
        //MISSING ID COMPLETED RECIPE
        public async Task<IActionResult> Comment(int id, String userId, String commentary)
        {
            var idCompleted = 1;

            var userCompletedRecipe = _context.UserCompletedRecipes.Find(idCompleted);
            
            var comment = new Comment
            {
                UserCompletedRecipe = userCompletedRecipe, Text = commentary
            };
            
           // _context.UserCompletedRecipes.Find(idCompleted).Comments.Add(comment);
            
            
            
            //falta aparecer algum pop up a dizer que o comentário foi adicionado
            //caixa com o comentário ficar vazia depois de aparecer o pop up
            
            return RedirectToAction("Index", "Rate", new { Id = id, CommentSent = true });
        }
    }
}
