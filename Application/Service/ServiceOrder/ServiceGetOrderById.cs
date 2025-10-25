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
                    orderNumber: ord.OrderId,
                    totalAmount: ord.Price,
                    deliveryTo: ord.DeliveryTo,
                    notes: ord.Notes,
                    status: new CreateStatusOrder(
                            id: ord.OStatusId,
                            name: ord.OverallStatus.NameStatus
                        ),
                    deliveryType: new CreateDeliveryOrder(
                            id: ord.DeliveryTypeId,
                            name: ord.deliveryType.NameDeliveryT
                        ),
                    orderItems: ord.OrderItemsO.Select(oi => new CreateOrderItemResponce(
                            id: oi.OrderId,
                            quantity: oi.Quantity,
                            notes: oi.Notes,
                            status: new CreateOIStatus(
                                    id: oi.StatusId,
                                    name: oi.Status.NameStatus
                                ),
                            dish: new CreateOIDish(
                                    id: oi.DishId,
                                    name: oi.Dish.NameDish,
                                    image: oi.Dish.ImageUrl
                                )
                        )).ToList(),
                    createdAt: ord.CreateDate,
                    updatedAt: ord.UpdateDate
                ));
        }
    }
}
