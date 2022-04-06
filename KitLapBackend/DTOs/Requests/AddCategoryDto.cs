using System.ComponentModel.DataAnnotations;

namespace KitLapBackend.DTOs.Requests
{
    public class AddCategoryDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
