using Application.DTOs;
using Application.Interfaces.InterfacesOrder;
using Application.Response;
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
        private readonly IServiceGetOrderByID _getOrderByID;
        private readonly IServiceUpdateOrderItem _updateOrderItem;
        private readonly IServiceUpdateStatusOrder _updateStatusOrder;

        public OrderController(IServiceCreateOrder serviceCreateOrder, IServiceFilterOrder filterOrder, IServiceGetOrderByID serviceGetOrderByID, IServiceUpdateOrderItem updateOrderItem, IServiceUpdateStatusOrder updateStatusOrder)
        {
            _serviceCreateOrder = serviceCreateOrder;
            _filterOrder = filterOrder;
            _getOrderByID = serviceGetOrderByID;
            _updateOrderItem = updateOrderItem;
            _updateStatusOrder = updateStatusOrder;
        }

        [HttpPost]
        public async Task<IActionResult> createOrder([FromBody] CreateOrderRequest order)
        {
            var result = await _serviceCreateOrder.createOrder(order);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet]
        public async Task<IActionResult> filterOrder([FromQuery] DateTime? inicio, [FromQuery] DateTime? fin, [FromQuery] int? statusId)
        {
            var result = await _filterOrder.filterOrder(inicio, fin, statusId);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getOrderById(long id)
        {
            var result = await _getOrderByID.getOrderById(id);
            return new JsonResult(result);
        }

        [HttpPatch]
        public async Task<IActionResult> updateOrderItem([FromQuery] long id, [FromBody] List<UpdateOrderItemRequest> items)
        {
            var result = await _updateOrderItem.updateOrderItemList(id, items);
            return new JsonResult(result);
        }

        [HttpPatch("{id}/item/{itemId}")]
        public async Task<IActionResult> updateStatusOrder(long id, long itemId, [FromBody] UpdateStatusOrderRequest status)
        {
            var result = await _updateStatusOrder.updateStatusOrder(id, itemId, status);
            return new JsonResult(result);
        }
    }
}
