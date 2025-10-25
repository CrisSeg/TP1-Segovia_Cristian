using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateOrderItemRequest
    {
        [Required]
        public Guid id { get; init; }
        [Required]
        public int quantity { get; init; }
        [Required]
        public string notes { get; init; } = string.Empty;
    }
}
