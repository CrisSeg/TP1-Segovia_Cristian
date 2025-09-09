using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace menuRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IServicesDishCreate _service;
        private readonly ISeviceDishGet _servicesGet; 

        public DishController(IServicesDishCreate service, ISeviceDishGet serviceGet)
        {
            _service = service;
            _servicesGet = serviceGet;
        }
        // Implement actions for the DishController here
        [HttpPost]
        public async Task<IActionResult> CreateDish(CreateDishRequest request)
        {
            var result = await _service.createDish(request);
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDishById(Guid id)
        {
           var result = await _servicesGet.getDishById(id);
           return new JsonResult(result);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _servicesGet.GetCategoryById(id);
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDishes()
        {
            var result = await _servicesGet.GetAllDishes();
            return new JsonResult(result);
        }
    }
}
