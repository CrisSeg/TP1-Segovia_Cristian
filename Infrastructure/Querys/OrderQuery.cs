using Application.Interfaces.InterfacesOrder;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppContext = Infrastructure.Persistence.AppContext;

namespace Infrastructure.Querys
{
    public class OrderQuery : IOrderQuery
    {
        private readonly AppContext _context;

        public OrderQuery(AppContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> getAll()
            => await _context.Orders.AsNoTracking()
                .Include(o => o.OverallStatus)
                .Include(o => o.deliveryType)
                .ToListAsync();

        public async Task<string?> getStatusById(int id)
            => await _context.Orders.AsNoTracking()
                .Where(o => o.OStatusId == id)
                .Select(o => o.OverallStatus.NameStatus)
                .FirstOrDefaultAsync();

        public async Task<string?> getDeliveryTipeId(int id)
            => await _context.Orders.AsNoTracking()
                .Where(o => o.DeliveryTypeId == id)
                .Select(o => o.deliveryType.NameDeliveryT)
                .FirstOrDefaultAsync();
    }
}
