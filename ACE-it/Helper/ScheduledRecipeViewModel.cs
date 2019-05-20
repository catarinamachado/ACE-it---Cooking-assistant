using System;
using ACE_it.Models;

namespace ACE_it.Helper
{
    public class ScheduledRecipeViewModel
    {
        private Recipe Recipe { get; set; }
        private DateTime Date { get; set; }

        public ScheduledRecipeViewModel(Recipe recipe, DateTime date)
        {
            Recipe = recipe;
            Date = date;
        }
    }
}