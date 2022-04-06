﻿using KitLapBackend.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KitLapBackend.DTOs.Responses
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }
        public RatingsStatsDto RatingStats { get; set; }
        public bool HasDiscount { get; set; }
        public int DiscountRate { get; set; }
        public float DiscountedPrice { get; set; }
    }
}
