using System.ComponentModel.DataAnnotations;

namespace KitLapBackend.DTOs.Requests
{
    public class AddProductDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public bool HasDiscount { get; set; }
        public int DiscountRate { get; set; }
    }
}
