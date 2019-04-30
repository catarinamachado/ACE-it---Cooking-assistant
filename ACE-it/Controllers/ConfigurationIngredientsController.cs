using System.Linq;
using System.Threading.Tasks;
using ACE_it.Data;
using ACE_it.Helper;
using ACE_it.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;


namespace ACE_it.Controllers
{
    public class ConfigurationIngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfigurationIngredientsController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        // GET: Ingredients
        public async Task<IActionResult> Index(
            string sortOrder, string currentFilter,
            string searchString, int? pageNumber)
        {
            var ingredients = from s in _context.Ingredients select s;
            
            var user = _context.AppUsers
                .First(r => r.Email == User.Identity.Name);

            var userIngredients = (from s in _context.UserFavouriteIngredients
                where s.UserId == user.Id select s)
                .Include(r => r.Ingredient)
                .ToListAsync();
            
            var userUnwanted = (from s in _context.UserUnwantedIngredients
                where s.UserId == user.Id select s)
                .ToListAsync();;

            if (searchString != null)
                pageNumber = 1;
            else
                searchString = currentFilter;

            ingredients = Search(ingredients, searchString);
            ingredients = OrderSwitch(ingredients, sortOrder);

            var pageSize = 5;
            var i = await PaginatedList<Ingredient>.CreateAsync(
                ingredients.AsNoTracking(),
                pageNumber ?? 1, pageSize);
            
            
            return View(new ConfigurationIngredientViewModel(
                user, i, await userIngredients, await userUnwanted));
        }

        
        // PRIVATE
        
        
        private IQueryable<Ingredient> Search(
            IQueryable<Ingredient> ingredients, string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            if (!string.IsNullOrEmpty(searchString))
                ingredients = ingredients.Where(
                    s => s.Name.ToLower().Contains(
                        searchString.Trim().ToLower()));

            return ingredients;
        }

        private IQueryable<Ingredient> OrderSwitch(
            IQueryable<Ingredient> ingredients, string sortOrder)
        {
            ViewData["NameSortParam"] =
                string.IsNullOrEmpty(sortOrder) || sortOrder == "name_desc" ? "name_asc" : "name_desc";

            switch (sortOrder)
            {
                case "name_desc":
                    ingredients = ingredients.OrderByDescending(s => s.Name);
                    break;
                default:
                    ingredients = ingredients.OrderBy(s => s.Name);
                    break;
            }

            return ingredients;
        }
    }
}