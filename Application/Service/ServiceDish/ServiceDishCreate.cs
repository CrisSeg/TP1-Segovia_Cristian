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
    public class ServiceDishCreate : IServicesDishCreate
    {
        private readonly IDishCommand _dishCommand;
        private readonly IDishQuery _dishQuery;
        private readonly ISeviceDishGet _servicesGet;

        public ServiceDishCreate(IDishCommand dishCommand, IDishQuery dishQuery, ISeviceDishGet servicesGet)
        {
            _dishCommand = dishCommand;
            _dishQuery = dishQuery;
            _servicesGet = servicesGet;
        }

        public async Task<CreateDishResponse> createDish(CreateDishRequest request)
        {
            var dishes = await _servicesGet.GetAllDishes();

            if (request.name == null)
                throw new BadRequestException("El nombre no puede ser vacio.");
            if (request.price <= 0)
                throw new BadRequestException("El precio debe ser mayor a 0");
            if (dishes.Any(d => d.name == request.name))
                throw new ConflictException($"Ya existe un plato con el nombre: '{request.name}'.");


            var now = DateTime.UtcNow;  

            var dish = new Dish
            {
                NameDish = request.name,
                Description = request.description ?? string.Empty, 
                Price = request.price,
                Avialable = true,
                ImageUrl = request.image ?? string.Empty,
                CategoryId = request.category,
                CreateDate = now,
                UpdateDate = now,
            };

            await _dishCommand.AddDish(dish);

            var CategoryName = await _dishQuery.GetCategoryById(dish.CategoryId) ?? string.Empty;

            return new CreateDishResponse(
                id: dish.DishId, 
                name: dish.NameDish, 
                description: dish.Description, 
                price: dish.Price, 
                new CreateDishCategory(
                        id: dish.CategoryId,
                        name: CategoryName
                    ),  
                image: dish.ImageUrl, 
                isActive: dish.Avialable, 
                createdAt: dish.CreateDate,
                updatedAt: dish.UpdateDate
            );
        }
    }
}
