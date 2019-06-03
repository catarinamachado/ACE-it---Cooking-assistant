using ACE_it.Models;

namespace ACE_it.Helper
{
    public class RateViewModel
    {
        public User User { get; set; }
        public Recipe Recipe { get; set; }
        public bool ReviewSent { get; set; }
        public UserCompletedRecipe UserCompletedRecipe { get; set; }

        public RateViewModel(
            User user,
            Recipe recipe,
            bool reviewSent,
            UserCompletedRecipe userCompletedRecipe)
        {
            User = user;
            Recipe = recipe;
            ReviewSent = reviewSent;
            UserCompletedRecipe = userCompletedRecipe;
        }
    }
}
