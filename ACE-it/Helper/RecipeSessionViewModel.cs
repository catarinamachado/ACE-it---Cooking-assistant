using ACE_it.Models;

namespace ACE_it.Helper
{
    public class RecipeSessionViewModel
    {
        public RecipeInstruction RecipeInstruction { get; }
        public int SessionId { get; }
        public int InstructionIndex { get; }
        public int RecipeInstructionsCount { get; }
        public int ViewIndex { get; }

        public RecipeSessionViewModel(RecipeInstruction recipeInstruction, int sessionId, int instructionIndex, int recipeInstructionsCount, int viewIndex)
        {
            RecipeInstruction = recipeInstruction;
            SessionId = sessionId;
            InstructionIndex = instructionIndex;
            RecipeInstructionsCount = recipeInstructionsCount;
            ViewIndex = viewIndex;
        }
    }
}
