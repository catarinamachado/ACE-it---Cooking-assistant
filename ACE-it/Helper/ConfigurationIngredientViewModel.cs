using System.Collections.Generic;
using ACE_it.Models;

namespace ACE_it.Helper
{
    public class ConfigurationIngredientViewModel
    {
        public User User { get; set; }
        public PaginatedList<Ingredient> Ingredients { get; set; }
        public List<UserFavouriteIngredient> FavouriteIngredients { get; set; }
        public List<UserUnwantedIngredient> UnwantedIngredients { get; set; }

        public ConfigurationIngredientViewModel(
            User user,
            PaginatedList<Ingredient> ingredients, 
            List<UserFavouriteIngredient> favouriteIngredients, 
            List<UserUnwantedIngredient> unwantedIngredients)
        {
            User = user;
            Ingredients = ingredients;
            FavouriteIngredients = favouriteIngredients;
            UnwantedIngredients = unwantedIngredients;
        }
    }
}
