using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class UserFavouriteRecipe
    {
        [Required] public string UserId { get; set; }
        [Required] public User User { get; set; }

        public int RecipeId { get; set; }
        [Required] public Recipe Recipe { get; set; }
    }
}
