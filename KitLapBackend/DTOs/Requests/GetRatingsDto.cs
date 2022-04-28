using System.ComponentModel.DataAnnotations;

namespace KitLapBackend.DTOs.Requests
{
    public class GetRatingsDto
    {
        [Required]
        public int ProductId { get; set; }
    }
}
