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
        public int RecipeId { get; }
        public bool GoBack { get; }

        public RecipeSessionViewModel(RecipeInstruction recipeInstruction, int sessionId,
            int instructionIndex, int recipeInstructionsCount, int viewIndex, int recipeId, bool goBack)
        {
            RecipeInstruction = recipeInstruction;
            SessionId = sessionId;
            InstructionIndex = instructionIndex;
            RecipeInstructionsCount = recipeInstructionsCount;
            ViewIndex = viewIndex;
            RecipeId = recipeId;
            GoBack = goBack;
        }
    }
}
