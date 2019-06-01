using System.Collections.Generic;
using ACE_it.Models;

namespace ACE_it.Helper
{
    public class RecipeDetailsViewModel
    {
        public Recipe Recipe { get; }
        public int? SessionId { get; }
        public List<Comment> Comments { get; set; }

        public RecipeDetailsViewModel(Recipe recipe, int? sessionId, List<Comment> comments)
        {
            Recipe = recipe;
            SessionId = sessionId;
            Comments = comments;
        }
    }
}