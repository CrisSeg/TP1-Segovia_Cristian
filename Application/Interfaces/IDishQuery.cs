using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDishQuery
    {
        Task<List<Dish>> GetAllDishes();
        Task<Dish> GetDishById(Guid id);
        Task<string?> GetCategoryById(int id);
    }
}
