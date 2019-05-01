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
            [Bind("UserId, IngredientId")] UserFavouriteIngredient userFavouriteIngredient,
            int? pageNumber)
        {
            var isAUnwantedIngredient = 
                _context.UserUnwantedIngredients.Find
                    (userFavouriteIngredient.UserId, userFavouriteIngredient.IngredientId) != null;
            
            if(!isAUnwantedIngredient)
            {
                _context.Add(userFavouriteIngredient);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index", "ConfigurationIngredients", new { pageNumber });
        }
        
        public ActionResult Delete(
            [Bind("UserId, IngredientId")] UserFavouriteIngredient userFavouriteIngredient,
            int? pageNumber)
        {
            _context.Remove(userFavouriteIngredient);
            _context.SaveChanges();
           
            return RedirectToAction("Index", "ConfigurationIngredients", new { pageNumber });
        }
    }
}
