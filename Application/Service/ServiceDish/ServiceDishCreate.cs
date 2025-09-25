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

            if (request.NameDish == null)
                throw new BadRequestException("El nombre no puede ser vacio.");
            if (request.Price <= 0)
                throw new BadRequestException("El precio debe ser mayor a 0");
            if (dishes.Any(d => d.Name == request.NameDish))
                throw new ConflictException($"Ya existe un plato con el nombre: '{request.NameDish}'.");


            var now = DateTime.UtcNow;  

            var dish = new Dish
            {
                NameDish = request.NameDish,
                Description = request.Description ?? string.Empty, 
                Price = request.Price,
                Avialable = request.avialible,
                ImageUrl = request.ImageUrl ?? string.Empty,
                CategoryId = request.CategoryId,
                CreateDate = now,
                UpdateDate = now,
            };

            await _dishCommand.AddDish(dish);

            var CategoryName = await _dishQuery.GetCategoryById(dish.CategoryId) ?? string.Empty;

            return new CreateDishResponse(
                dish.DishId, dish.NameDish, dish.Description, dish.Price, dish.Avialable, dish.ImageUrl, dish.CreateDate, dish.UpdateDate, dish.CategoryId, CategoryName
            );
        }
    }
}
