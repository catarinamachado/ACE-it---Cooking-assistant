using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class SessionRecipe
    {
        public int Id { get; set; }

        [Required] public Recipe Recipe { get; set; }

        public int Index { get; set; }
        public int Order { get; set; }
    }
}
