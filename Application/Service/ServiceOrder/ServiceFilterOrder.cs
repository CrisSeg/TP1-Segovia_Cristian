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
                    orderId: o.OrderId,
                    price: o.Price,
                    deliveryTo: o.DeliveryTo,
                    notes: o.Notes,
                    statusId: o.OStatusId,
                    status: o.OverallStatus.NameStatus,
                    deliveryId: o.DeliveryTypeId,
                    deliveryType: o.deliveryType.NameDeliveryT,
                    orderItems: o.OrderItemsO.Select(oi => new CreateOrderItemResponce(
                            orderItemId : oi.OrderItemId,
                            quantity : oi.Quantity,
                            notes : oi.Notes,
                            oStatusId : oi.StatusId,
                            oStatus : oi.Status.NameStatus,
                            oDishId : oi.DishId,
                            oDishName : oi.Dish.NameDish,
                            oDishImage : oi.Dish.ImageUrl
                        )).ToList(),
                    createDate : o.CreateDate,
                    updateDate : o.UpdateDate
                )).ToList();
        }
    }
}
