using FirstLine.Task.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstLine.Task
{
    public class CartService : ICartService
    {
        private Dictionary<Item, int> items = new Dictionary<Item, int>();
        public void Add(Item item)
        {
            if (items.TryGetValue(item, out int quantity))
            {
                items[item] = ++quantity;
            }
            else
            {
                items.Add(item, 1);
            }
        }
        public void Remove(Item item)
        {
            if (items.TryGetValue(item, out int quantity))
            {
                quantity--;
                if (quantity > 0)
                {
                    items[item] = quantity;
                }
                else
                {
                    items.Remove(item);
                }
            }
        }
        public decimal GetTotal()
        {
            decimal total = 0;

            foreach (var itemWithQuantity in items)
            {
                var quantity = itemWithQuantity.Value;
                var item = itemWithQuantity.Key;
                if (item.DiscountPrice == 0)
                {
                    total += item.Price * quantity;
                }
                else
                {
                    var dicountBatchesQuantity = quantity / item.DiscountQuantity;
                    var noDiscountItemsQuantity = quantity % item.DiscountQuantity;

                    total += dicountBatchesQuantity * item.DiscountPrice + item.Price * noDiscountItemsQuantity;
                }
            }

            return total;
        }
    }
}
