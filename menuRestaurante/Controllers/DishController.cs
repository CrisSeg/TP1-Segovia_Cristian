using Application.DTOs;
using Application.Enums;
using Application.Interfaces.InterfaceDish;
using Domain.Entities;
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
        private readonly IServicesDishUpdate _serviceUpdate;
        private readonly IServiceDishFilter _serviceFilter;
        private readonly IServiceDeleteDish _serviceDeleteDish;

        public DishController(IServicesDishCreate service, ISeviceDishGet serviceGet, IServicesDishUpdate serviceUp,IServiceDishFilter serviceDishFilter, IServiceDeleteDish serviceDeleteDish)
        {
            _service = service;
            _servicesGet = serviceGet;
            _serviceUpdate = serviceUp;
            _serviceFilter = serviceDishFilter;
            _serviceDeleteDish = serviceDeleteDish;
        }
        // Implement actions for the DishController here
        [HttpPost]
        public async Task<IActionResult> CreateDish(CreateDishRequest request)
        {   
            var result = await _service.createDish(request);
            return new JsonResult(result) { StatusCode = 201};
        }

        [HttpGet("dish")]
        public async Task<IActionResult> FilterDish([FromQuery] string? name, [FromQuery] int? categoryId, [FromQuery] SortOrder orderByAsc, [FromQuery] bool? avialable)
        {
            var result = await _serviceFilter.FilterDishesByPriceRange(name, categoryId, orderByAsc, avialable);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDish(Guid id, UpdateDishRequest request)
        {
            var result = await _serviceUpdate.updateDish(id, request);
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDishById(Guid id)
        {
           var result = await _servicesGet.getDishById(id);
           return new JsonResult(result);
        }

       [HttpPatch("{id}")]
        public async Task<IActionResult> DeleteDish(Guid id)
        {
            var result = await _serviceDeleteDish.DeleteDish(id);
            return new JsonResult(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _servicesGet.GetCategoryById(id);
            return new JsonResult(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public async Task<IActionResult> GetAllDishes()
        {
            var result = await _servicesGet.GetAllDishes();
            return new JsonResult(result);
        }
    }
}
