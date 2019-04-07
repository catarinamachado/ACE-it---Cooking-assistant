using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        [Required] public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        [Required] public Ingredient Ingredient { get; set; }

        public int Quantity { get; set; }
    }
}
