using Application.Exceptions;
using Application.Interfaces.InterfaceOrderItem;
using Application.Interfaces.InterfacesOrder;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceOrder
{
    public class ServiceFilterOrder : IServiceFilterOrder
    {
        private readonly IOrderQuery _orderQuery;
        private readonly IOrderItemQuery _itemQuery;

        public ServiceFilterOrder(IOrderQuery orderQuery, IOrderItemQuery itemQuery)
        {
            _orderQuery = orderQuery;
            _itemQuery = itemQuery;
        }

        public async Task<List<CreateFilterOrderResponce>> filterOrder(DateTime? inicio, DateTime? fin, int? statusId)
        {
            DateTime now = DateTime.Now;
            IEnumerable<Order> orders = await _orderQuery.getAll();

            if (fin >= now.AddMinutes(35))
            {
                throw new BadRequestException("Rango de fecha invalida.");
            }

            IEnumerable<Order> filter = orders;

            if (inicio.HasValue)
            {
                filter = filter.Where(o => o.CreateDate == inicio);
            }
            if (fin.HasValue)
            {
                filter = filter.Where(o => o.UpdateDate == fin);
            }
            if (statusId.HasValue)
            {
                filter = filter.Where(o => o.OStatusId == statusId);
            }

            return filter.Select(o => new CreateFilterOrderResponce(
                    orderNumber: o.OrderId,
                    totalAmount: o.Price,
                    deliveryTo: o.DeliveryTo,
                    notes: o.Notes,
                    status: new CreateStatusOrder(
                            id: o.OStatusId,
                            name: o.OverallStatus.NameStatus
                        ),
                    deliveryType: new CreateDeliveryOrder(
                            id: o.DeliveryTypeId,
                            name: o.deliveryType.NameDeliveryT
                        ),
                    orderItems: o.OrderItemsO.Select(oi => new CreateOrderItemResponce(
                            id: oi.OrderItemId,
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
                    createdAt : o.CreateDate,
                    updatedAt : o.UpdateDate
                )).ToList();
        }
    }
}
