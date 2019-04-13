using System.ComponentModel.DataAnnotations;

namespace ACE_it.Models
{
    public class InstructionTool
    {
        public int InstructionId { get; set; }
        [Required] public Instruction Instruction { get; set; }

        public int ToolId { get; set; }
        [Required] public Tool Tool { get; set; }
    }
}
