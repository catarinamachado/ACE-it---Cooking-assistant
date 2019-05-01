using System.Linq;
using System.Threading.Tasks;
using ACE_it.Data;
using ACE_it.Helper;
using ACE_it.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACE_it.Controllers
{
    public class UserFavouriteRecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserFavouriteRecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            string sortOrder, string currentFilter,
            string searchString, int? pageNumber)
        {
            var recipes = from s in _context.Recipes select s;
            
            var user = _context.AppUsers
                .First(r => r.Email == User.Identity.Name);

            var userRecipes = (from s in _context.UserFavouriteRecipes
                    where s.UserId == user.Id select s)
                .Include(r => r.Recipe)
                .ToListAsync();

            if (searchString != null)
                pageNumber = 1;
            else
                searchString = currentFilter;

            recipes = Search(recipes, searchString);
            recipes = OrderSwitch(recipes, sortOrder);

            var pageSize = 5;
            var i = await PaginatedList<Recipe>.CreateAsync(
                recipes.AsNoTracking(),
                pageNumber ?? 1, pageSize);
            
            return View(new UserFavouriteRecipeViewModel(
                user, i, await userRecipes));
        }
        
        [HttpPost]
        public ActionResult Store(
            [Bind("UserId, RecipeId")] UserFavouriteRecipe userFavouriteRecipe,
            int? pageNumber)
        {
            _context.Add(userFavouriteRecipe);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "UserFavouriteRecipes", new { pageNumber });
        }
        
        public ActionResult Delete(
            [Bind("UserId, RecipeId")] UserFavouriteRecipe userFavouriteRecipe,
            int? pageNumber)
        {
            _context.Remove(userFavouriteRecipe);
            _context.SaveChanges();
           
            return RedirectToAction("Index", "UserFavouriteRecipes", new { pageNumber });
        }
        
        // PRIVATE
        
        private IQueryable<Recipe> Search(
            IQueryable<Recipe> recipes, string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            if (!string.IsNullOrEmpty(searchString))
                recipes = recipes.Where(
                    s => s.Name.ToLower().Contains(
                        searchString.Trim().ToLower()));

            return recipes;
        }

        private IQueryable<Recipe> OrderSwitch(
            IQueryable<Recipe> recipes, string sortOrder)
        {
            ViewData["NameSortParam"] =
                string.IsNullOrEmpty(sortOrder) || sortOrder == "name_desc" ? "name_asc" : "name_desc";

            switch (sortOrder)
            {
                case "name_desc":
                    recipes = recipes.OrderByDescending(s => s.Name);
                    break;
                default:
                    recipes = recipes.OrderBy(s => s.Name);
                    break;
            }

            return recipes;
        }
    }
}
