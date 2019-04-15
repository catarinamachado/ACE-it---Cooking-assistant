using System.Linq;
using System.Threading.Tasks;
using ACE_it.Data;
using ACE_it.Helper;
using ACE_it.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACE_it.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index(
            string sortOrder, string currentFilter,
            string searchString, int? pageNumber)
        {
            var ingredients = from s in _context.Ingredients select s;

            if (searchString != null)
                pageNumber = 1;
            else
                searchString = currentFilter;

            ingredients = Search(ingredients, searchString);
            ingredients = OrderSwitch(ingredients, sortOrder);

            var pageSize = 5;
            return View(await PaginatedList<Ingredient>.CreateAsync(
                ingredients.AsNoTracking(),
                pageNumber ?? 1, pageSize));
        }

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
            ViewData["CaloriesSortParam"] =
                sortOrder == "calories_asc" ? "calories_desc" : "calories_asc";

            switch (sortOrder)
            {
                case "name_desc":
                    ingredients = ingredients.OrderByDescending(s => s.Name);
                    break;
                case "calories_asc":
                    ingredients = ingredients.OrderBy(s => s.Calories);
                    break;
                case "calories_desc":
                    ingredients =
                        ingredients.OrderByDescending(s => s.Calories);
                    break;
                default:
                    ingredients = ingredients.OrderBy(s => s.Name);
                    break;
            }

            return ingredients;
        }
    }
}