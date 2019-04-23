using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ACE_it.Models
{
    public class User : IdentityUser
    {
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required] public Difficulty Difficulty { get; set; }

        public int NumberOfCoupons { get; set; }
        public int NumberOfVisits { get; set; }

        [Required] public List<UserFavouriteIngredient> UserFavouriteIngredients { get; set; }
        [Required] public List<UserUnwantedIngredient> UserUnwantedIngredients { get; set; }
        [Required] public List<UserFavouriteRecipe> UserFavouriteRecipes { get; set; }
        [Required] public List<UserCompletedRecipe> UserCompletedRecipes { get; set; }
        [Required] public List<UserWillPrepareRecipe> UserWillPrepareRecipes { get; set; }
        [Required] public List<UserReactedToRecipe> UserReactedToRecipes { get; set; }
    }
}
