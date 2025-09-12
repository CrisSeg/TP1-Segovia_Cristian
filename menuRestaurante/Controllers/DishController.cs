using Application.DTOs;
using Application.Enums;
using Application.Interfaces;
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

        public DishController(IServicesDishCreate service, ISeviceDishGet serviceGet, IServicesDishUpdate serviceUp,IServiceDishFilter serviceDishFilter )
        {
            _service = service;
            _servicesGet = serviceGet;
            _serviceUpdate = serviceUp;
            _serviceFilter = serviceDishFilter;
        }
        // Implement actions for the DishController here
        [HttpPost]
        public async Task<IActionResult> CreateDish(CreateDishRequest request)
        {
            var dishes = await _servicesGet.GetAllDishes();

            if (request.NameDish == null)
                return BadRequest("El nombre del plato es obligatorio");
            if(request.Price <= 0)
                return BadRequest("El precio debe ser mayor a 0");
            if (dishes.Any(d => d.Name == request.NameDish))
                return Conflict($"Ya existe un plato con el nombre: '{request.NameDish}'.");
            
            var result = await _service.createDish(request);
            return new JsonResult(result) { StatusCode = 201};
        }

        [HttpGet("dish")]
        public async Task<IActionResult> FilterDish([FromQuery] string? name, [FromQuery] int? categoryId, [FromQuery] SortOrder orderByAsc, [FromQuery] bool? avialable)
        {
            var dishes = await _servicesGet.GetAllDishes();
            if ((name != null && dishes.Any(d => d.Name != name)) || (categoryId != null && dishes.Any(d => d.CategoryId != categoryId)))
                return NotFound("No se encontraron platos con los criterios especificados.");
            var result = await _serviceFilter.FilterDishesByPriceRange(name, categoryId, orderByAsc, avialable);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDish(Guid id, UpdateDishRequest request)
        {
            var dishes = await _servicesGet.GetAllDishes();
            if (!dishes.Any(d => d.DishId == id))
                return NotFound($"El plato con la ID '{id}' no exite.");
            if (dishes.Any(d => d.Name == request.NameDish))
                return Conflict($"Ya existe un plato con el nombre: '{request.NameDish}'.");
            if (request.Price <= 0)
                return BadRequest("El precio debe ser mayor a 0");

            var result = await _serviceUpdate.updateDish(id, request);
            return new JsonResult(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDishById(Guid id)
        {
           var result = await _servicesGet.getDishById(id);
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
