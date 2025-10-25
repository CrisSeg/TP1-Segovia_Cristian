using Application.Interfaces.InterfaceCategory;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceCategory
{
    public class ServiceCategoryGet: IServiceCategoryGet
    {
        private readonly ICategoryQuery _categoryQuery;

        public ServiceCategoryGet(ICategoryQuery categoryQuery)
        {
            _categoryQuery = categoryQuery;
        }

        public async Task<List<CreateCategoryResponse>> GetAllCategories()
        {
            var categories = await _categoryQuery.GetAllcategories();

            var response = categories.Select(category => new CreateCategoryResponse(
                Id: category.Id,
                name: category.NameCategory,
                description: category.Description,
                order : category.Order
            )).ToList();

            return response;
        }
    }
}
