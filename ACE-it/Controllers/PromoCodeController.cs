using System;
using System.Linq;
using System.Threading.Tasks;
using ACE_it.Data;
using ACE_it.Helper;
using Microsoft.AspNetCore.Mvc;

namespace ACE_it.Controllers
{
    public class PromoCodeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static Random random = new Random();
        
        public PromoCodeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var randCode = RandomString(8);
            var expireDate = DateTime.Today.AddMonths(1);
            
            return View(new PromoCodeViewModel(randCode, expireDate));
        }
        
        public async Task<IActionResult> Store(String userId)
        {
            var user = _context.Users.Find(userId);

            user.NumberOfCoupons++;
            
            _context.Update(user);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "PromoCode");
        }
        
        //PRIVATE
        
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
