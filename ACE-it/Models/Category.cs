using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(45)] public string Name { get; set; }
    }
}
