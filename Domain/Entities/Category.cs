using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        
        public string NameCategory { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Order { get; set; }

        // Collection navigation containing dependents
        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
