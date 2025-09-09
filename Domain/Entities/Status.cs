using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Status
    {
        public int Id { get; set; }

        public string NameStatus { get; set; } = null!;

        public ICollection<OrderItem> SOrderItems { get; set; } = new List<OrderItem>();
    
        public ICollection<Order> SOrders { get; set; } = new List<Order>();
    }
}
