using System;
using System.ComponentModel.DataAnnotations;

namespace ACE_it.Helper
{
    public class ShoppingListRequest
    {
        [Required]
        public string Start { get; set; }

        [Required]
        public string End { get; set; }
    }
}