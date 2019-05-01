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
            [Bind("UserId, IngredientId")] UserUnwantedIngredient userUnwantedIngredient,
            int? pageNumber)
        {
            var isAFavouriteIngredient = 
                _context.UserFavouriteIngredients.Find(
                    userUnwantedIngredient.UserId, userUnwantedIngredient.IngredientId) != null;

            if(!isAFavouriteIngredient)
            {
                _context.Add(userUnwantedIngredient);
                _context.SaveChanges();
            }
           
            return RedirectToAction("Index", "ConfigurationIngredients", new { pageNumber });
        }
        
        public ActionResult Delete(
            [Bind("UserId, IngredientId")] UserUnwantedIngredient userUnwantedIngredient,
            int? pageNumber)
        {
            _context.Remove(userUnwantedIngredient);
            _context.SaveChanges();
           
            return RedirectToAction("Index", "ConfigurationIngredients", new { pageNumber });
        }
    }
}
