using Application.Interfaces.InterfacesOrder;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppContext = Infrastructure.Persistence.AppContext;

namespace Infrastructure.Commands
{
    public class OrderCommand : IOrderCommand
    {
        private readonly AppContext _context;

        public OrderCommand(AppContext context)
        {
            _context = context;
        }

        public async Task addOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task updateOrder(long orderId, int statuId)
        {
            var order = new Order
            {
                OrderId = orderId,
                OStatusId = statuId,
            };

            _context.Orders.Attach(order);
            _context.Entry(order).Property(o => o.OStatusId).IsModified = true;

            await _context.SaveChangesAsync();
        }

        public async Task updateOrderItem(long orderItemId, int statuId)
        {
            var orderItem = new OrderItem
            {
                OrderItemId = orderItemId,
                StatusId = statuId,
            };

            _context.orderItems.Attach(orderItem);
            _context.Entry(orderItem).Property(oi => oi.StatusId).IsModified= true;
            await _context.SaveChangesAsync();
        }
    }
}
