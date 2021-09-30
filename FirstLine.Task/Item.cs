using System;
using System.Collections.Generic;
using System.Text;

namespace FirstLine.Task
{
    public class Item
    {
        public Item(string sku)
        {
            Sku = sku;
        }

        public Item(string sku, decimal price, decimal discountPrice, int discountQuantity)
        {
            Sku = sku;
            Price = price;
            DiscountPrice = discountPrice;
            DiscountQuantity = discountQuantity;
        }

        public string Sku { get; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public int DiscountQuantity { get; set; }

        public override int GetHashCode()
        {
            return Sku.GetHashCode();
        }
    }
}
