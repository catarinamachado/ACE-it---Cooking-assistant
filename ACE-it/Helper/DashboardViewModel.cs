using System.Collections.Generic;
using System.Linq;
using ACE_it.Models;

namespace ACE_it.Helper
{
    public class DashboardViewModel
    {
        public User User { get; set; }
        public List<IGrouping<int,UserCompletedRecipe>> UserCompletedRecipes { get; set; }

        public DashboardViewModel(User user, List<IGrouping<int,UserCompletedRecipe>> userCompletedRecipes)
        {
            User = user;
            UserCompletedRecipes = userCompletedRecipes;
        }
    }
}
