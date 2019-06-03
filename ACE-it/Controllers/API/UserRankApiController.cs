using System.Threading.Tasks;
using ACE_it.Data;
using ACE_it.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACE_it.Controllers.API
{
    public class UserRankApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserRankApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("API/UserRank/Up")]
        public async Task<IActionResult> RankUp()
        {
            if (!User.Identity.IsAuthenticated) return Unauthorized();
            var user = await _context.AppUsers.FirstAsync(r => r.Email == User.Identity.Name);
            var changed = false;

            switch (user.Difficulty)
            {
               case Difficulty.Easy:
                   user.Difficulty = Difficulty.Medium;
                   changed = true;
                   break;
               case Difficulty.Medium:
                   user.Difficulty = Difficulty.Hard;
                   changed = true;
                   break;
            }

            if (changed)
            {
                _context.AppUsers.Update(user);
                _context.SaveChanges();
            }

            return Ok(changed);
        }

        [Route("API/UserRank/Down")]
        public async Task<IActionResult> RankDown()
        {
            if (!User.Identity.IsAuthenticated) return Unauthorized();
            var user = await _context.AppUsers.FirstAsync(r => r.Email == User.Identity.Name);
            var changed = false;

            switch (user.Difficulty)
            {
                case Difficulty.Medium:
                    user.Difficulty = Difficulty.Easy;
                    changed = true;
                    break;
                case Difficulty.Hard:
                    user.Difficulty = Difficulty.Medium;
                    changed = true;
                    break;
            }

            if (changed)
            {
                _context.AppUsers.Update(user);
                _context.SaveChanges();
            }

            return Ok(changed);
        }
    }
}
