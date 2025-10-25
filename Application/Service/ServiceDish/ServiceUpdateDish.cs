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

        public async Task<CreateDishResponse> updateDish(Guid id, UpdateDishRequest request)
        {
            var dish = await _dishQuery.GetDishById(id);
            if (dish is null)
                throw new NotFoundException($"No se encontró el plato con ID {id}");
            var di = await _dishQuery.GetAllDishes();
            if (di.Any(d => d.NameDish == request.name && d.DishId != id))
                throw new ConflictException($"Ya existe un plato con el nombre: '{request.name}'");
            if (request.price <= 0)
                throw new BadRequestException("El precio debe ser mayor a 0");

            await _dishCommand.updateDish(id, request);

             return new CreateDishResponse(
                    id: id,
                    name: request.name,
                    description: request.description,
                    price: request.price,
                    new CreateDishCategory(
                        id: request.category,
                        name: dish.Category.NameCategory
                    ),
                    image: request.image,
                    isActive: request.IsActive,
                    createdAt: dish.CreateDate,
                    updatedAt: dish.UpdateDate
                );
        }
    }
}
