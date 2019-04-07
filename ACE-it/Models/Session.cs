using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class Session
    {
        public int Id { get; set; }

        [Required] public User User { get; set; }
        [Required] public List<SessionRecipe> SessionRecipes { get; set; }
    }
}
