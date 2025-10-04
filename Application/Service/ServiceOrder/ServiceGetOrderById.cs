using Application.Exceptions;
using Application.Interfaces.InterfacesOrder;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceOrder
{
    public class ServiceGetOrderById : IServiceGetOrderByID
    {
        private readonly IOrderQuery _orderQuery;

        public ServiceGetOrderById(IOrderQuery orderQuery)
        {
            _orderQuery = orderQuery;
        }

        public async Task<CreateFilterOrderResponce> getOrderById(long id)
        {
            var order = await _orderQuery.getAll();

            if (!order.Any(o => o.OrderId == id))
                throw new NotFoundException("Orden no encontrada.");

            var ord = await _orderQuery.GetOrderById(id);

            return await Task.FromResult(new CreateFilterOrderResponce(
                    orderId: ord.OrderId,
                    price: ord.Price,
                    deliveryTo: ord.DeliveryTo,
                    notes: ord.Notes,
                    statusId: ord.OStatusId,
                    status: ord.OverallStatus.NameStatus,
                    deliveryId: ord.DeliveryTypeId,
                    deliveryType: ord.deliveryType.NameDeliveryT,
                    orderItems: ord.OrderItemsO.Select(oi => new CreateOrderItemResponce(
                            orderItemId: oi.OrderId,
                            quantity: oi.Quantity,
                            notes: oi.Notes,
                            oStatusId: oi.StatusId,
                            oStatus: oi.Status.NameStatus,
                            oDishId: oi.DishId,
                            oDishName: oi.Dish.NameDish,
                            oDishImage: oi.Dish.ImageUrl
                        )).ToList(),
                    createDate : ord.CreateDate,
                    updateDate : ord.UpdateDate
                ));
        }
    }
}
