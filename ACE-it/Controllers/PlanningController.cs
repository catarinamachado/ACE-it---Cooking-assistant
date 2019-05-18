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
    public class PlanningController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public PlanningController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Show(string rawStart, string rawEnd)
        {
            var start = DateTime.Parse(rawStart);
            var end = DateTime.Parse(rawEnd);

            var user = await _context.AppUsers
                .Where(r => r.Email == User.Identity.Name)
                .FirstAsync();

            var ucr = await _context.UserWillPrepareRecipes
                .Where(d => d.UserId == user.Id && d.Date >= start && d.Date <= end)
                .Include(u => u.Recipe)
                    .ThenInclude(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .ToListAsync();

            var map = new Dictionary<int, ShoppingItem>();
            
            foreach (var userUserWillPrepareRecipe in ucr)
            {
                foreach (var recipeRecipeIngredient in userUserWillPrepareRecipe.Recipe.RecipeIngredients)
                {
                    var ingredient = recipeRecipeIngredient.Ingredient;

                    if (map.ContainsKey(ingredient.Id))
                    {
                        var shoppingItem = map[ingredient.Id];
                        shoppingItem.Quantity += recipeRecipeIngredient.Quantity;
                    }
                    else
                    {
                        map.Add(ingredient.Id, new ShoppingItem(ingredient, recipeRecipeIngredient.Quantity));
                    }
                }
            }
            
            return View(new ShoppingItems(map, start, end));
        }
    }
}