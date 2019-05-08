using System;
using ACE_it.Models;

namespace ACE_it.Helper
{
    public class RateViewModel
    {
        public User User { get; set; }
        public Recipe Recipe { get; set; }
        public bool ReviewSent { get; set; }
        
        public RateViewModel(
            User user,
            Recipe recipe,
            bool reviewSent)
        {
            User = user;
            Recipe = recipe;
            ReviewSent = reviewSent;
        }
    }
}
