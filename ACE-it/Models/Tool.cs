using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class Tool
    {
        public int Id { get; set; }

       [Required, MaxLength(45)] public string Name { get; set; }

       [Required] public List<InstructionTool> InstructionTools { get; set; }
    }
}
