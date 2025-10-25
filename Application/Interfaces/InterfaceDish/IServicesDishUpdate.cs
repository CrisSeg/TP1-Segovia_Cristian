using Application.DTOs;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfaceDish
{
    public interface IServicesDishUpdate
    {
        Task<CreateDishResponse> updateDish(Guid Id, UpdateDishRequest request);
    }
}
