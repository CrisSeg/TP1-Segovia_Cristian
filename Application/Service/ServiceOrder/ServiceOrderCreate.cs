using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces.InterfaceDish;
using Application.Interfaces.InterfacesOrder;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceOrder
{
    public class ServiceOrderCreate : IServiceCreateOrder
    {
        private readonly IOrderCommand _command;
        private readonly IOrderQuery _query;
        private readonly IDishQuery _dishQuery;

        public ServiceOrderCreate(IOrderCommand command, IOrderQuery query, IDishQuery dishQuery)
        {
            _command = command;
            _query = query;
            _dishQuery = dishQuery;
        }

        public async Task<CreateOrderResponse> createOrder(CreateOrderRequest o)
        {
            var dishes = await _dishQuery.GetAllDishes();
            var dish = dishes.ToDictionary(d => d.DishId, d => d.Avialable);
            var pre = dishes.ToDictionary(p => p.DishId, p => p.Price);
            double pr = 0.0;

            foreach (var item in o.items)
            {
                dish.TryGetValue(item.DishID, out var isAvialable);
                if(isAvialable == false || !dish.ContainsKey(item.DishID))
                    throw new BadRequestException("El plato especificado no existe o no esta disponible");
            }

            foreach(var item in o.items)
            {
                if (pre.TryGetValue(item.DishID, out var isPrice))
                    pr += Convert.ToDouble(item.Quantity) * isPrice;
            }

            var now = DateTime.Now;
            var update = now.AddMinutes(35);

            var order = new Order
            {
                DeliveryTo = o.delivery.to,
                Notes = o.notes,
                Price = pr,
                CreateDate = now,
                UpdateDate = update,
                OStatusId = 1,
                DeliveryTypeId = o.delivery.deliveryId
            };

            foreach (var item in o.items)
            {
                order.OrderItemsO.Add(new OrderItem
                {
                    Quantity = item.Quantity,
                    Notes = item.Notes,
                    CreateDate= now
                }); 
            }
            
            await _command.addOrder(order);

            return new CreateOrderResponse(
                    order.OrderId, order.Price, order.CreateDate
                );
        }
    }
}
