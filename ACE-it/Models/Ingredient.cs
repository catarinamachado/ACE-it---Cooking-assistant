using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required, MaxLength(45)] public string Name { get; set; }

        public double Calories { get; set; }
        public double TotalFat { get; set; }
        public double SaturatedFat { get; set; }
        public double Sodium { get; set; }
        public double Sugar { get; set; }
        public double Protein { get; set; }
        public double TotalCarbohydrate { get; set; }
        public double Fiber { get; set; }

        public int Quantity { get; set; }
        public string Unit { get; set; }

        [Required] public List<RecipeIngredient> RecipeIngredients { get; set; }
        [Required] public List<UserFavouriteIngredient> UserFavouriteIngredients { get; set; }
        [Required] public List<UserUnwantedIngredient> UserUnwantedIngredients { get; set; }
    }
}
