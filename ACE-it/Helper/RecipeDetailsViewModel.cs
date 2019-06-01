using System.Collections.Generic;
using ACE_it.Models;

namespace ACE_it.Helper
{
    public class RecipeDetailsViewModel
    {
        public Recipe Recipe { get; }
        public int? SessionId { get; }
        public List<Comment> Comments { get; }
        public string UserId { get; }
        public List<string> Difficulties { get; }

        public RecipeDetailsViewModel(Recipe recipe, int? sessionId, List<Comment> comments, string userId, List<string> difficulties)
        {
            Recipe = recipe;
            SessionId = sessionId;
            Comments = comments;
            UserId = userId;
            Difficulties = difficulties;
        }
    }
}