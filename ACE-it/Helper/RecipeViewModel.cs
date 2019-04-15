using System.Collections.Generic;
using ACE_it.Models;

namespace ACE_it.Helper
{
    public class RecipeViewModel
    {
        public List<Recipe> Recipes { get; set; }
        public List<Category> Categories { get; set; }

        public RecipeViewModel(List<Recipe> recipes, List<Category> categories)
        {
            Recipes = recipes;
            Categories = categories;
        }
    }
}
