using Application.DTOs;
using Application.Interfaces.InterfaceDish;
using Application.Response;
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

        public async Task updateDish(Guid id ,UpdateDishRequest dish)
        {
            var d = await _context.Dishes.FindAsync(id);

            d.NameDish = dish.NameDish;
            d.Description = dish.Description;
            d.Price = dish.Price;
            d.CategoryId = dish.CategoryId;
            d.ImageUrl = dish.ImageUrl;
            d.Avialable = dish.IsAvailable;

            _context.Dishes.Update(d);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDish(Guid id, bool isDelete)
        {
            var dish = new Dish
            {
                DishId = id,
                IsDelete = isDelete
            };

            _context.Dishes.Attach(dish);
            _context.Entry(dish).Property(d => d.IsDelete).IsModified = true;
            await _context.SaveChangesAsync();
        }
    }
}
