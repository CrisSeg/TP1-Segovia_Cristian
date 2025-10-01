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
    }
}
