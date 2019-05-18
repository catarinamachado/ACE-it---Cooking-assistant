
using ACE_it.Models;

namespace ACE_it.Helper
{
    public class ShoppingItem
    {
        public Ingredient Ingredient { get; set; }
        public double Quantity { get; set; }

        public ShoppingItem(Ingredient ingredient, double quantity)
        {
            Ingredient = ingredient;
            Quantity = quantity;
        }
    }
}