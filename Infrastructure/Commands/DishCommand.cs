using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppContext = Infrastructure.Persistence.AppContext;

namespace Infrastructure.Commands
{
    public class DishCommand : IDishCommand
    {
        private readonly AppContext _context;

        public DishCommand(AppContext context)
        {
            _context = context;
        }

        public async Task AddDish(Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
        }

        public Task DeleteDish(int dishId)
        {
            throw new NotImplementedException();
        }
    }
}
