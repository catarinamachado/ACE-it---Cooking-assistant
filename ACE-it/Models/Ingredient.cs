using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required, MaxLength(45)] public string Name { get; set; }

        public int Calories { get; set; }
        public int TotalFat { get; set; }
        public int SaturedFat { get; set; }
        public int Sodium { get; set; }
        public int Sugar { get; set; }
        public int Protein { get; set; }
        public int TotalCarbohydrate { get; set; }

        [Required] public List<RecipeIngredient> RecipeIngredients { get; set; }
        [Required] public List<UserFavouriteIngredient> UserFavouriteIngredients { get; set; }
        [Required] public List<UserUnwantedIngredient> UserUnwantedIngredients { get; set; }
    }
}
