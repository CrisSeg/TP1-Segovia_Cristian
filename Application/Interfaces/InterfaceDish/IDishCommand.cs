using Application.DTOs;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfaceDish
{
    public interface IDishCommand
    {
        Task AddDish(Dish dish);
        Task<UpdateDishRequest> UpdateDish(Guid id, UpdateDishRequest request);
    }
}
