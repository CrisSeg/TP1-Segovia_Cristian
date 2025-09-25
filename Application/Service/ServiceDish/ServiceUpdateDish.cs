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
            var dishes = await _serviceDishGet.GetAllDishes();
            if (!dishes.Any(d => d.DishId == id))
                throw new NotFoundException($"El plato con la ID '{id}' no exite.");
            if (dishes.Any(d => d.Name == request.NameDish))
                throw new ConflictException($"Ya existe un plato con el nombre: '{request.NameDish}'.");
            if (request.Price <= 0)
                throw new BadRequestException("El precio debe ser mayor a 0");


            var dish = await _dishQuery.GetDishById(id);
            if (dish is null)
                throw new KeyNotFoundException($"No se encontró el plato con ID {id}");

            dish.NameDish = request.NameDish;
            dish.Description = request.Description;
            dish.Price = request.Price;
            dish.CategoryId = request.CategoryId;
            dish.ImageUrl = request.ImageUrl;
            dish.Avialable = request.IsAvailable;

            return request;
        }
    }
}
