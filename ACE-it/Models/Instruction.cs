using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class Instruction
    {
        public int Id { get; set; }

        [Required, DataType(DataType.Text), MaxLength(1000)]
        public string Text { get; set; }

        [Required] public InstructionType InstructionType { get; set; }

        public Recipe Recipe { get; set; }

        [Required] public List<RecipeInstruction> RecipeInstructions { get; set; }
        [Required] public List<InstructionTool> InstructionTools { get; set; }
    }
}
