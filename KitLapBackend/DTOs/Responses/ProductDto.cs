using KitLapBackend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitLapBackend.DTOs.Responses
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public float Price { get; set; }
        public RatingsStatsDto RatingStats { get; set; }
        [Required]
        public bool HasDiscount { get; set; }
        public int DiscountRate { get; set; }
        public float DiscountedPrice { get; set; }

    }
}
