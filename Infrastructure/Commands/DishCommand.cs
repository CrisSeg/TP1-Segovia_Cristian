using Application.DTOs;
using Application.Interfaces;
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

        public async Task<UpdateDishRequest> UpdateDish(Guid id ,UpdateDishRequest updateDish)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish is null)
                throw new KeyNotFoundException($"No se encontró el plato con ID {id}");

            dish.NameDish = updateDish.NameDish;
            dish.Description = updateDish.Description;
            dish.Price = updateDish.Price;
            dish.CategoryId = updateDish.CategoryId;
            dish.ImageUrl = updateDish.ImageUrl;

            await _context.SaveChangesAsync();

            return updateDish;
        }
    }
}
