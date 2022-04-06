using System;
using System.ComponentModel.DataAnnotations;

namespace KitLapBackend.DTOs.Requests
{
    public class AddRatingDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required, Range(0,5)]
        public int RatingValue { get; set; }
    }
}
