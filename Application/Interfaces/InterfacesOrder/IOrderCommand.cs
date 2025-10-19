using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfacesOrder
{
    public interface IOrderCommand
    {
        Task addOrder(Order order);
        Task updateListOrderItems(Order order);
        Task updateOrderStatus(long orderId, int statuId);
        Task updateOrderItemStatus(long orderItemId, int statuId);
    }
}
