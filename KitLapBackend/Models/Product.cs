using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitLapBackend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }
        public ProductRating Rating { get; set; }
        public bool HasDiscount { get; set; } = false;
        public int DiscountValue { get; set; } = 0;
        public float DiscountedPrice { get; set; }

        public Product()
        {
            DiscountedPrice = ((100 - DiscountValue) / 100) * Price;
        }
    }
}
