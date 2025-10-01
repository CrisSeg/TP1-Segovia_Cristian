using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateOrderRequest
    {
        [Required]
        public List<CreateOrderItemRequest> items { get; init; } = new();
        [Required]
        public DeliveryTypeRequest delivery { get; init; }
        [Required]
        public string notes { get; init; } = string.Empty;
    }
}
