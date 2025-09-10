using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateDishRequest
    {
        [Required]
        public string NameDish { get; init; } = default!;
        [MaxLength(500)]
        public string? Description { get; init; }
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public double Price { get; init; }
        public string? ImageUrl { get; init; }
        [Required]
        public int CategoryId { get; init; }
    }
}
