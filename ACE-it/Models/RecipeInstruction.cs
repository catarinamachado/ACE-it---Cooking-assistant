using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class RecipeInstruction
    {
        public int RecipeId { get; set; }
        public int InstructionId { get; set; }

        [Required] public Recipe Recipe { get; set; }
        [Required] public Instruction Instruction { get; set; }

        public int Index { get; set; }
    }
}
