using System.Collections.Generic;
using ACE_it.Models;

namespace ACE_it.Helper
{
    public class UserFavouriteRecipeViewModel
    {
        public User User { get; set; }
        public PaginatedList<Recipe> Recipes { get; set; }
        public List<UserFavouriteRecipe> FavouriteRecipes { get; set; }

        public UserFavouriteRecipeViewModel(
            User user,
            PaginatedList<Recipe> recipes, 
            List<UserFavouriteRecipe> favouriteRecipes)
        {
            User = user;
            Recipes = recipes;
            FavouriteRecipes = favouriteRecipes;
        }
    }
}
