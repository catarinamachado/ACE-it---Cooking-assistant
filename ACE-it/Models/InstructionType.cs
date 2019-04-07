using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class InstructionType
    {
        public int Id { get; set; }

        [Required, MaxLength(45)] public string Type { get; set; }
    }
}