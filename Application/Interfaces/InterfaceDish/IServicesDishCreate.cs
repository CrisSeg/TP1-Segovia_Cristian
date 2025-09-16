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
    public interface IServicesDishCreate
    {
        Task<CreateDishResponse> createDish(CreateDishRequest request); 
    }
}
