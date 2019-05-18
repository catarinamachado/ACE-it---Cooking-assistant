using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class UserCompletedRecipe
    {
        [Required] public int Id { get; set; }

        [Required] public string UserId { get; set; }
        [Required] public User User { get; set; }

        [Required] public int RecipeId { get; set; }
        [Required] public Recipe Recipe { get; set; }

        public int Duration { get; set; }

        [Required, MaxLength(45)] public string Difficulties { get; set; }

        [Required] public List<Comment> Comments { get; set; }
    }
}
