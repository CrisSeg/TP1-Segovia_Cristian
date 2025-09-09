using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Dish
    {
        public Guid DishId { get; set; }

        public string NameDish { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public bool Avialable { get; set; }
        public string ImageUrl { get; set; } = null!;

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        // Foreign Key con category
        public int CategoryId { get; set; }    
        public Category Category { get; set; } = null!;

        // Collection navigation containing dependents
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
