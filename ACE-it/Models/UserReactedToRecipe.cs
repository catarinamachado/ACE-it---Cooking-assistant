using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class UserReactedToRecipe
    {
        [Required] public string UserId { get; set; }
        [Required] public User User { get; set; }

        [Required] public int RecipeId { get; set; }
        [Required] public Recipe Recipe { get; set; }

        [Required] public Reaction Reaction { get; set; }
    }
}
