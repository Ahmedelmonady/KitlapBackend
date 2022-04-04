using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitLapBackend.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
