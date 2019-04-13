using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class UserCompletedRecipe
    {
        [Required] public string UserId { get; set; }
        [Required] public User User { get; set; }

        public int RecipeId { get; set; }
        [Required] public Recipe Recipe{ get; set; }

        public int Duration { get; set; }

        [Required] public Reaction Reaction { get; set; }
        [Required, MaxLength(45)] public string Difficulties { get; set; }
    }
}
