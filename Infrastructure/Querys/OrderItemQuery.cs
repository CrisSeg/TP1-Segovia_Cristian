using Application.Interfaces.InterfaceOrderItem;
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
    public class OrderItemQuery : IOrderItemQuery
    {
        private readonly AppContext _context;

        public OrderItemQuery(AppContext context)
        {
            _context = context;
        }

        public async Task<List<OrderItem>> getAllItems()
            => await _context.orderItems.AsNoTracking()
                    .Include(oi => oi.Dish)
                    .Include(oi => oi.Status)
                    .ToListAsync();

        public async Task<int> countDishByOrderItem(Guid id)
        {
            int count = await _context.orderItems.CountAsync(oi => oi.DishId == id);
            return count;
        }

        public async Task<string?> getDishId(Guid id)
            => await _context.orderItems.AsNoTracking()
                .Where(o => o.DishId == id)
                .Select(o => o.Dish.NameDish)
                .FirstOrDefaultAsync();

        public async Task<string?> getDishImage(Guid id)
            => await _context.orderItems.AsNoTracking()
                .Where(o => o.DishId == id)
                .Select(o => o.Dish.ImageUrl)
                .FirstOrDefaultAsync();

        public async Task<string?> getStatusId(int id)
            => await _context.orderItems.AsNoTracking()
                .Where(o => o.StatusId == id)
                .Select(o => o.Status.NameStatus)
                .FirstOrDefaultAsync();
        
    }
}
