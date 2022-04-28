using System.ComponentModel.DataAnnotations;

namespace KitLapBackend.DTOs.Requests
{
    public class GetCategoriesDto
    {
        [Required]
        public int ProductId { get; set; }
    }
}
