using Application.Interfaces.InterfaceCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace menuRestaurante.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceCategoryGet serviceCategoryGet;

        public CategoryController(IServiceCategoryGet serviceCategoryGet)
        {
            this.serviceCategoryGet = serviceCategoryGet;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await serviceCategoryGet.GetAllCategories();
            return new JsonResult(categories);
        }
    }
}
