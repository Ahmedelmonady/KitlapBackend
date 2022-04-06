using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
