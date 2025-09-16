using Application.DTOs;
using Application.Enums;
using Application.Interfaces.InterfaceDish;
using Application.Response;
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
    public class DishQuery : IDishQuery
    {
        private readonly AppContext _context;

        public DishQuery(AppContext context)
        {
            _context = context;
        }

        public async Task<List<Dish>> GetAllDishes()
            => await _context.Dishes.AsNoTracking()
                .Include(d => d.Category)
                .ToListAsync();

        public async Task<string?> GetCategoryById(int id)
            => await _context.Dishes.AsNoTracking()
                .Where(d => d.CategoryId == id)
                .Select(d => d.Category.NameCategory)
                .FirstOrDefaultAsync();

        public async Task<Dish> GetDishById(Guid id)
        {
            Dish? dish = await _context.Dishes.AsNoTracking()
                            .Include(d => d.Category)
                            .FirstOrDefaultAsync(d => d.DishId == id);
            return dish;
        }

        public async Task<List<Dish>> GetFilterDish(string? name, int? categoryId, SortOrder orderByAsc, bool? avialable)
        {
            return  await _context.Dishes.AsNoTracking().Include(d => d.Category).ToListAsync();
        }
    }
}
