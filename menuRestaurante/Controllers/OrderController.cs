using Application.DTOs;
using Application.Interfaces.InterfacesOrder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace menuRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IServiceCreateOrder _serviceCreateOrder;
        private readonly IServiceFilterOrder _filterOrder;

        public OrderController(IServiceCreateOrder serviceCreateOrder, IServiceFilterOrder filterOrder)
        {
            _serviceCreateOrder = serviceCreateOrder;
            _filterOrder = filterOrder;
        }

        [HttpPost]
        public async Task<IActionResult> createOrder([FromBody] CreateOrderRequest order)
        {
            var result = await _serviceCreateOrder.createOrder(order);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet("order")]
        public async Task<IActionResult> filterOrder([FromQuery] DateTime inicio, [FromQuery] DateTime fin, [FromQuery] int statusId)
        {
            var result = await _filterOrder.filterOrder(inicio, fin, statusId);
            return new JsonResult(result) { StatusCode = 200 };
        }

    }
}
