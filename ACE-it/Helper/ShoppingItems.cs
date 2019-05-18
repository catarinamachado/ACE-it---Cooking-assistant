using System;
using System.Collections.Generic;

namespace ACE_it.Helper
{
    public class ShoppingItems
    {
        public Dictionary<int, ShoppingItem> ShoppingItemsMap { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public ShoppingItems(Dictionary<int, ShoppingItem> shoppingItemsMap, DateTime start, DateTime end)
        {
            ShoppingItemsMap = shoppingItemsMap;
            Start = start;
            End = end;
        }
    }
}
