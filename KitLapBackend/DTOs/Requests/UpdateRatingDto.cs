using System;
using System.ComponentModel.DataAnnotations;

namespace KitLapBackend.DTOs.Requests
{
    public class UpdateRatingDto
    {
        [Required]
        public int RatingId { get; set; }
        [Required, Range(0,5)]
        public int RatingValue { get; set; }
    }
}
