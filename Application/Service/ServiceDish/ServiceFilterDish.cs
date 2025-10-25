using Application.DTOs;
using Application.Enums;
using Application.Exceptions;
using Application.Interfaces.InterfaceDish;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceDish
{
    public class ServiceFilterDish : IServiceDishFilter
    {
        private readonly IDishCommand _dishCommand;
        private readonly IDishQuery _dishQuery;
        private readonly ISeviceDishGet _servicesGet;

        public ServiceFilterDish(IDishCommand dishCommand, IDishQuery dishQuery, ISeviceDishGet servicesGet)
        {
            _dishCommand = dishCommand;
            _dishQuery = dishQuery;
            _servicesGet = servicesGet;
        }

        public async Task<List<CreateDishResponse>> FilterDishesByPriceRange(string? name, int? categoryId, SortOrder orderByAsc, bool? avialable)
        {
            var dishes = await _dishQuery.GetAllDishes();

            IEnumerable<Dish> filter = dishes;

            // Filtrar por nombre
            if (!string.IsNullOrEmpty(name))
            {
                filter = filter.Where(dish => dish.NameDish.Contains(name));
            }

            // Filtrar por categoría
            if (categoryId.HasValue)
            {
                filter = filter.Where(dish => dish.CategoryId == categoryId);
            }

            //Filtrar por disponibilidad
            if (avialable.HasValue)
            {
                filter = filter.Where(dish => dish.Avialable == avialable);
            }

            filter = orderByAsc == SortOrder.ASC
                ? filter.OrderBy(dish => dish.Price)
                : filter.OrderByDescending(dish => dish.Price);

            if (!filter.Any())
                throw new NotFoundException("No se encontraton platos con los criterios especificados");

            return filter.Select(d => new CreateDishResponse(
                    id: d.DishId,
                    name: d.NameDish,
                    description: d.Description,
                    price: d.Price,
                    new CreateDishCategory(
                        id: d.CategoryId,
                        name: d.Category.NameCategory
                     ),
                    image: d.ImageUrl,
                    isActive: d.Avialable,
                    createdAt: d.CreateDate,
                    updatedAt: d.UpdateDate
                )).ToList();
        }
    }
}
