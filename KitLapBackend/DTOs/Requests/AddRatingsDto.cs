using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitLapBackend.DTOs.Requests
{
    public class AddRatingsDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required, Range(0,5)]
        public float RatingValue { get; set; }
    }
}
