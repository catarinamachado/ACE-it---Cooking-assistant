using System.Threading.Tasks;
using ACE_it.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACE_it.Controllers.API
{
    public class RecipesApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [Route("API/Recipes")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Recipes.ToListAsync());
        }
    }
}