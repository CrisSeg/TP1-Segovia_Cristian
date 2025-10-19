using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces.InterfaceDish;
using Application.Interfaces.InterfacesOrder;
using Application.Response;
using Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceOrder
{
    public class ServiceUpdateOrderItem : IServiceUpdateOrderItem
    {
        private readonly IOrderCommand _command;
        private readonly IOrderQuery _orderQuery;
        private readonly IDishQuery _dishQuery;

        public ServiceUpdateOrderItem(IOrderCommand ordercommand, IOrderQuery orderQuery, IDishQuery dishQuery)
        {
            _command = ordercommand;
            _orderQuery = orderQuery;
            _dishQuery = dishQuery;
        }

        public async Task<UpdateOrderByItemResponse> updateOrderItemList(long id, List<UpdateOrderItemRequest> items)
        {
            var orderById = await _orderQuery.GetOrderById(id);

            var dishes = await _dishQuery.GetAllDishes();
            var dishStatus = dishes.ToDictionary(d => d.DishId, d => d.Avialable);
            var dishPrice = dishes.ToDictionary(p => p.DishId, p => p.Price);

            double price = 0.0;

            if (orderById.OStatusId != 1)
                throw new BadRequestException("No se puede modificar una orden que ya está en preparación");

            if (orderById.OrderItemsO == null)
                orderById.OrderItemsO = new List<OrderItem>();

            foreach (var item in items)
            {
                if (!dishStatus.TryGetValue(item.DishID, out var isAvialable) || !isAvialable)
                    throw new BadRequestException("El plato no se encuentra disponible");

                var exist = orderById.OrderItemsO
                    .FirstOrDefault(oi => oi.DishId == item.DishID);
                if (exist == null)
                    orderById.OrderItemsO.Add(new OrderItem
                    {
                        DishId = item.DishID,
                        Quantity = item.Quantity,
                        Notes = item.Notes,
                        StatusId = 1,
                        CreateDate = DateTime.Now
                    });
                else
                {
                    exist.Quantity = item.Quantity;
                    exist.Notes = item.Notes;
                }

                if (dishPrice.TryGetValue(item.DishID, out double isPrice))
                    price += Convert.ToDouble(item.Quantity) * isPrice;
            }

            orderById.Price = price;
            orderById.UpdateDate = DateTime.Now.AddMinutes(35);

            await _command.updateListOrderItems(orderById);

            return new UpdateOrderByItemResponse(
                    orderById.OrderId, orderById.Price, orderById.UpdateDate
                );
        }
    }
}
