using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateDishRequest
    {
        [Required]
        public string name { get; init; } = default!;
        [MaxLength(500)]
        public string? description { get; init; }
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public double price { get; init; }
        [Required]
        public int category { get; init; }
        public string? image { get; init; } 
    }
}
