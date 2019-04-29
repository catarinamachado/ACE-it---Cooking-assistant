using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class SessionRecipe
    {
        public SessionRecipe(Recipe recipe)
        {
            Recipe = recipe;
            Index = 0;
            Order = 0;
        }

        public int Id { get; set; }

        [Required] public Recipe Recipe { get; set; }

        private int Index { get; set; }
        private int Order { get; set; }
    }
}
