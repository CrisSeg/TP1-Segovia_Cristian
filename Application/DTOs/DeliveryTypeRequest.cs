using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DeliveryTypeRequest
    {
        [Required]
        public int deliveryId { get; init; }
        [Required]
        public string to { get; init; }
    }
}
