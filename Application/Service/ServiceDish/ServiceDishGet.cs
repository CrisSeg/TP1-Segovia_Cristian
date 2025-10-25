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
    public class ServiceDishGet : ISeviceDishGet
    {
        private readonly IDishCommand _dishCommand;
        private readonly IDishQuery _dishQuery;

        public ServiceDishGet(IDishCommand dishCommand, IDishQuery dishQuery)
        {
            _dishCommand = dishCommand;
            _dishQuery = dishQuery;
        }

        public async Task<List<CreateDishResponse>> GetAllDishes()
        {
            var dishes = await _dishQuery.GetAllDishes();
            var response = dishes.Select(dish => new CreateDishResponse(
                id: dish.DishId,
                name: dish.NameDish,
                description: dish.Description,
                price: dish.Price,
                new CreateDishCategory(
                     id: dish.CategoryId,
                     name: dish.Category.NameCategory
                  ),
                image: dish.ImageUrl,
                isActive: dish.Avialable,
                createdAt: dish.CreateDate,
                updatedAt: dish.UpdateDate
            )).ToList();
            return response;
        }

        public async Task<CreateDishResponse> getDishById(Guid id)
        {
            var di = await _dishQuery.GetAllDishes();
            if (!di.Any(d => d.DishId == id))
                throw new NotFoundException("Plato no encontrado");

            var dish = await _dishQuery.GetDishById(id);

            return await Task.FromResult(new CreateDishResponse(
                id: dish.DishId,
                name: dish.NameDish,
                description: dish.Description,
                price: dish.Price,
                new CreateDishCategory(
                    id: dish.CategoryId,
                    name: dish.Category.NameCategory
                ),
                image: dish.ImageUrl,
                isActive: dish.Avialable,
                createdAt: dish.CreateDate,
                updatedAt: dish.UpdateDate
            ));
        }

        public async Task<string> GetCategoryById(int id)
        {
            var categoryName = await _dishQuery.GetCategoryById(id);
            return categoryName;
        }
    }
}
