using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(45)] public string Name { get; set; }

        [Required] public List<Recipe> Recipes { get; set; }

        public Category()
        {
        }

        public Category(int id)
        {
            Id = id;
        }
    }
}
