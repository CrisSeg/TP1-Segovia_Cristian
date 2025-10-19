using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces.InterfaceDish;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceDish
{
    public class ServiceUpdateDish : IServicesDishUpdate
    {
        private readonly IDishCommand _dishCommand;
        private readonly IDishQuery _dishQuery;
        private readonly ISeviceDishGet _serviceDishGet;

        public ServiceUpdateDish(IDishCommand dishCommand, IDishQuery dishQuery, ISeviceDishGet serviceDishGet)
        {
            _dishCommand = dishCommand;
            _dishQuery = dishQuery;
            _serviceDishGet = serviceDishGet;
        }

        public async Task<UpdateDishRequest> updateDish(Guid id, UpdateDishRequest request)
        {
            var dish = await _dishQuery.GetDishById(id);
            if (dish is null)
                throw new NotFoundException($"No se encontró el plato con ID {id}");
            var di = await _dishQuery.GetAllDishes();
            if (di.Any(d => d.NameDish == request.NameDish))
                throw new ConflictException($"Ya existe un plato con el nombre: '{request.NameDish}'");
            if (request.Price <= 0)
                throw new BadRequestException("El precio debe ser mayor a 0");
            /*
            dish.NameDish = request.NameDish;
            dish.Description = request.Description;
            dish.Price = request.Price;
            dish.CategoryId = request.CategoryId;
            dish.ImageUrl = request.ImageUrl;
            dish.Avialable = request.IsAvailable;
            */

            await _dishCommand.updateDish(id, request);

            return request;
        }
    }
}
