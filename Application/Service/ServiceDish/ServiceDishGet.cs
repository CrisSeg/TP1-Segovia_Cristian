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
                DishId: dish.DishId,
                Name: dish.NameDish,
                Description: dish.Description,
                Price: dish.Price,
                Avialable: dish.Avialable,
                ImageUrl: dish.ImageUrl,
                CreateDate: dish.CreateDate,
                UpdateDate: dish.UpdateDate,
                CategoryId: dish.CategoryId,
                CategoryName: dish.Category.NameCategory
            )).ToList();
            return response;
        }

        public async Task<CreateDishResponse> getDishById(Guid id)
        {
            var dish = await _dishQuery.GetDishById(id);

            return await Task.FromResult(new CreateDishResponse(
                DishId: dish.DishId,
                Name: dish.NameDish,
                Description: dish.Description,
                Price: dish.Price,
                Avialable: dish.Avialable,
                ImageUrl: dish.ImageUrl,
                CreateDate: dish.CreateDate,
                UpdateDate: dish.UpdateDate,
                CategoryId: dish.CategoryId,
                CategoryName: dish.Category.NameCategory
            ));
        }

        public async Task<string> GetCategoryById(int id)
        {
            var categoryName = await _dishQuery.GetCategoryById(id);
            return categoryName;
        }
    }
}
