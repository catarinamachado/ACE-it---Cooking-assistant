using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required, MaxLength(45)] public string Name { get; set; }
        [Required] public string Base64Image { get; set; }
        [Required, MaxLength(1000)] public string Description { get; set; }

        public int DefaultDuration { get; set; }
        public int NumberOfPeople { get; set; }

        [Required] public Difficulty Difficulty { get; set; }
        [Required] public Category Category { get; set; }

        [Required] public List<RecipeInstruction> RecipeInstructions { get; set; }
        [Required] public List<RecipeIngredient> RecipeIngredients { get; set; }
        [Required] public List<UserFavouriteRecipe> UserFavouriteRecipes { get; set; }
        [Required] public List<UserCompletedRecipe> UserCompletedRecipes { get; set; }
        [Required] public List<UserWillPrepareRecipe> UserWillPrepareRecipes { get; set; }
    }
}
