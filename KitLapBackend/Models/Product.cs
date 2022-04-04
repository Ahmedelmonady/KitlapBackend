﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitLapBackend.Models
{
    public class Product
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
        public List<Rating> Rating { get; set; }
        [Required]
        public bool HasDiscount { get; set; } = false;
        public int DiscountRate { get; set; } = 0;
    }
}
