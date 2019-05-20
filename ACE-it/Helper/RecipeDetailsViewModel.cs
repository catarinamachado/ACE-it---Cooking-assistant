using ACE_it.Models;

namespace ACE_it.Helper
{
    public class RecipeDetailsViewModel
    {
        public Recipe Recipe { get; }
        public int? SessionId { get; }

        public RecipeDetailsViewModel(Recipe recipe, int? sessionId)
        {
            Recipe = recipe;
            SessionId = sessionId;
        }
    }
}