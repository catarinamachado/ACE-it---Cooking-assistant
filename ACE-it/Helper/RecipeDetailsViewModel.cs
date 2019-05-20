using System.Collections.Generic;
using ACE_it.Models;

namespace ACE_it.Helper
{
    public class RecipeDetailsViewModel
    {
        public Recipe Recipe { get; set; }
        public List<Comment> Comments { get; set; }

        public RecipeDetailsViewModel(Recipe recipe, List<Comment> comments)
        {
            Recipe = recipe;
            Comments = comments;
        }
    }
}
