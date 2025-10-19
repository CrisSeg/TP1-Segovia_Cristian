using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces.InterfacesOrder;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceOrder
{
    public class ServiceUpdateStatusOrder : IServiceUpdateStatusOrder
    {
        private readonly IOrderCommand _command;
        private readonly IOrderQuery _orderQuery;

        public ServiceUpdateStatusOrder(IOrderCommand command, IOrderQuery orderQuery)
        {
            _command = command;
            _orderQuery = orderQuery;
        }

        public async Task<CreateOrderResponse> updateStatusOrder(long id, long itemId, UpdateStatusOrderRequest s)
        {
            var order = await _orderQuery.GetOrderById(id);

            var exist = order.OrderItemsO.FirstOrDefault(oi => oi.OrderItemId == itemId);

            if (order == null || exist == null) {
                throw new NotFoundException("Orden no encontrada");
            }
            if (s.status <= 0 || s.status >= 7)
                throw new BadRequestException("El estado especificado no es valido");

            await _command.updateOrderItemStatus(itemId, s.status);

            if(order.OrderItemsO.All(oi => oi.StatusId == 2))
                await _command.updateOrderStatus(order.OrderId, s.status);

            return new CreateOrderResponse(
                    order.OrderId, order.Price, order.CreateDate
                );
        }
    }
}
