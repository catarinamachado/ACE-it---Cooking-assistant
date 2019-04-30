using System;
using System.Linq;
using ACE_it.Data;
using ACE_it.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACE_it.Controllers
{
    public class UserUnwantedIngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserUnwantedIngredientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Store(
            [Bind("UserId, IngredientId")] UserUnwantedIngredient userUnwantedIngredient)
        {
            var isAFavouriteIngredient = 
                _context.UserFavouriteIngredients.Any(r => r.IngredientId == userUnwantedIngredient.IngredientId);
                        
            if(!isAFavouriteIngredient)
            {
                _context.Add(userUnwantedIngredient);
                _context.SaveChanges();
            }
           
            return RedirectToAction("Index", "ConfigurationIngredients");
        }
        
        public ActionResult Delete(
            [Bind("UserId, IngredientId")] UserUnwantedIngredient userUnwantedIngredient)
        {
            _context.Remove(userUnwantedIngredient);
            _context.SaveChanges();
           
            return RedirectToAction("Index", "ConfigurationIngredients");
        }
    }
}
