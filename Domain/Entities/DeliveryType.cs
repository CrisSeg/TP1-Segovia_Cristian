using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DeliveryType
    {
        public int IdD { get; set; }

        public string NameDeliveryT { get; set; } = null!;

        // Collection navigation containing dependents
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
