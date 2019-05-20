using System;
using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class UserWillPrepareRecipe
    {
        [Required] public int Id { get; set; }
        
        [Required] public string UserId { get; set; }
        [Required] public User User { get; set; }

        public int RecipeId { get; set; }
        [Required] public Recipe Recipe { get; set; }

        [Required] public DateTime Date { get; set; }
    }
}
