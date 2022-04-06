using KitLapBackend.Models;
using System.Collections.Generic;

namespace KitLapBackend.DTOs.Responses
{
    public class ProductDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }
        public List<RatingsDto> Ratings { get; set; }
        public bool HasDiscount { get; set; }
        public int DiscountRate { get; set; }
        public float DiscountedPrice { get; set; }
    }
}
