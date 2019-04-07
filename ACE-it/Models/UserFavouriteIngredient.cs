using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class UserFavouriteIngredient
    {
        [Required] public string UserId { get; set; }
        [Required] public User User { get; set; }

        public int IngredientId { get; set; }
        [Required] public Ingredient Ingredient { get; set; }
    }
}
