using ACE_it.Models;

namespace ACE_it.Helper
{
    public class RateViewModel
    {
        public User User { get; set; }
        public Recipe Recipe { get; set; }
        public bool ReviewSent { get; set; }
        public int UserCompletedRecipeId { get; set; }
        
        public RateViewModel(
            User user,
            Recipe recipe,
            bool reviewSent, 
            int userCompletedRecipeId)
        {
            User = user;
            Recipe = recipe;
            ReviewSent = reviewSent;
            UserCompletedRecipeId = userCompletedRecipeId;
        }
    }
}
