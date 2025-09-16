using Application.DTOs;
using Application.Enums;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfaceDish
{
    public interface IDishQuery
    {
        Task<List<Dish>> GetAllDishes();
        Task<Dish> GetDishById(Guid id);
        Task<string?> GetCategoryById(int id);

        Task<List<Dish>> GetFilterDish(string name, int? categoryId, SortOrder orderByAsc, bool? avialable);
    }
}
