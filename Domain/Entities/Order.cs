using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public long OrderId { get; set; }  

        public string DeliveryTo { get; set; } = null!;

        public string Notes { get; set; } = null!;

        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        // Collection navigation containg dependent
        public ICollection<OrderItem> OrderItemsO { get; set; } = new List<OrderItem>();

        // Foreign Key con Status
        public int OStatusId { get; set; }
        public Status OverallStatus { get; set; } = null!;

        // Foreign Key con DeliveryType
        public int DeliveryTypeId { get; set; }
        public DeliveryType deliveryType { get; set; } = null!;
    }
}
