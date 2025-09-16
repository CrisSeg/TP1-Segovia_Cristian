using Application.DTOs;
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

        public ServiceDishCreate(IDishCommand dishCommand, IDishQuery dishQuery)
        {
            _dishCommand = dishCommand;
            _dishQuery = dishQuery;
        }

        public async Task<CreateDishResponse> createDish(CreateDishRequest request)
        {
            var now = DateTime.UtcNow;  

            var dish = new Dish
            {
                NameDish = request.NameDish,
                Description = request.Description ?? string.Empty, 
                Price = request.Price,
                Avialable = false,
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
