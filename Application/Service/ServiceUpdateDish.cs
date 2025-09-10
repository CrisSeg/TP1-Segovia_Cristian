using Application.DTOs;
using Application.Interfaces;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ServiceUpdateDish : IServicesDishUpdate
    {
        private readonly IDishCommand _dishCommand;
        private readonly IDishQuery _dishQuery;

        public ServiceUpdateDish(IDishCommand dishCommand, IDishQuery dishQuery)
        {
            _dishCommand = dishCommand;
            _dishQuery = dishQuery;
        }

        public async Task<UpdateDishRequest> updateDish(Guid id ,UpdateDishRequest request)
        {

            return await _dishCommand.UpdateDish(id ,request);
            
        }
    }
}
