using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required] public UserCompletedRecipe UserCompletedRecipe { get; set; }
        [Required, MaxLength(120)] public string Text { get; set; }
    }
}
