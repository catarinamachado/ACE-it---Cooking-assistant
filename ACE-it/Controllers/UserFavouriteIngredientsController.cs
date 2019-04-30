using System;
using System.Linq;
using ACE_it.Data;
using ACE_it.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACE_it.Controllers
{
    public class UserFavouriteIngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserFavouriteIngredientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Store(
            [Bind("UserId, IngredientId")] UserFavouriteIngredient userFavouriteIngredient)
        {
            var isAUnwantedIngredient = 
                _context.UserUnwantedIngredients.Any(r => r.IngredientId == userFavouriteIngredient.IngredientId);
            
            if(!isAUnwantedIngredient){
                _context.Add(userFavouriteIngredient);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index", "ConfigurationIngredients");
        }
        
        public ActionResult Delete(
            [Bind("UserId, IngredientId")] UserFavouriteIngredient userFavouriteIngredient)
        {
            _context.Remove(userFavouriteIngredient);
            _context.SaveChanges();
           
            return RedirectToAction("Index", "ConfigurationIngredients");
        }
    }
}
