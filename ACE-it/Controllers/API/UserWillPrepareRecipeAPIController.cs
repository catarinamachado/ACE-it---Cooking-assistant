using System;
using System.Linq;
using System.Threading.Tasks;
using ACE_it.Data;
using ACE_it.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACE_it.Controllers.API
{
    public class UserWillPrepareRecipeAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserWillPrepareRecipeAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("API/UserWillPrepareRecipe/Index")]
        public async Task<IActionResult> Index()
        {
            var user = await _context.AppUsers
                .Where(r => r.Email == User.Identity.Name)
                .Include(us => us.UserWillPrepareRecipes)
                    .ThenInclude(u => u.Recipe)
                .FirstAsync();

            var array = new string[user.UserWillPrepareRecipes.Count];

            for (var i = 0; i < user.UserWillPrepareRecipes.Count; i++)
            {
                var r = user.UserWillPrepareRecipes[i];
                array[i] = r.Recipe.Id + "," + r.Recipe.Name + "," + r.Date.ToString("yyyy-MM-ddTHH:mm") + "," +
                           r.Recipe.DefaultDuration;
            }

            return Json(array);
        }

        [Route("API/UserWillPrepareRecipe/Create/{recipeId}/{rawDate}")]
        public async Task<IActionResult> Create(int recipeId, string rawDate)
        {
            var user = _context.AppUsers
                .Where(r => r.Email == User.Identity.Name)
                .Include(us => us.UserWillPrepareRecipes)
                .FirstAsync();
            var recipe = _context.Recipes.FindAsync(recipeId);
            var date = DateTime.Parse(rawDate);

            if (date < DateTime.Now)
            {
                return Json("Error: Date must be a present or future date");
            }
            
            var u = await user;
            var re = await recipe;
            var userWillPrepareRecipe = new UserWillPrepareRecipe { User = u, Recipe = re,  Date = date};
            
            u.UserWillPrepareRecipes.Add(userWillPrepareRecipe);
            _context.AppUsers.Update(u);
            _context.SaveChanges();
            
            return Json(re.Id + "," + re.Name + "," + date.ToString("yyyy-MM-ddTHH:mm") + "," + re.DefaultDuration);
        }
        
        [Route("API/UserWillPrepareRecipe/Delete/{recipeId}/{rawDate}")]
        public async Task<IActionResult> Delete(int recipeId, string rawDate)
        {
            var user = await _context.AppUsers
                .Where(r => r.Email == User.Identity.Name)
                .Include(us => us.UserWillPrepareRecipes)
                    .ThenInclude(us => us.Recipe)
                .FirstAsync();
            
            var date = DateTime.Parse(rawDate);

            var toRemove = user.UserWillPrepareRecipes.FindAll(wpr => wpr.Date == date && wpr.Recipe.Id == recipeId);
            foreach (var t in toRemove)
            {
                user.UserWillPrepareRecipes.Remove(t);
            }

            _context.AppUsers.Update(user);
            _context.SaveChanges();
            
            return Ok();
        }
    }
}