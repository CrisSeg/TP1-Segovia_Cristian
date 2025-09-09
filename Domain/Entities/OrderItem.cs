using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem
    {
        public long OrderItemId { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; } = null!;
        public DateTime CreateDate { get; set; }

        // Foreign Key con Dish
        public Dish Dish { get; set; } = null!;
        public Guid DishId { get; set; }

        // Foreign Key con Order
        public Order Order { get; set; } = null!;
        public long OrderId { get; set; }

        // Foreign Key con Status
        public int StatusId { get; set; }
        public Status Status { get; set; } = null!;
    }
}
