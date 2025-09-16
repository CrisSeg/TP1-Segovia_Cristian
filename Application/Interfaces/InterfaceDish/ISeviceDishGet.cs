using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfaceDish
{
    public interface ISeviceDishGet
    {
        Task<List<CreateDishResponse>> GetAllDishes();
        Task<CreateDishResponse> getDishById(Guid id);
        Task<string> GetCategoryById(int id);
    }
}
