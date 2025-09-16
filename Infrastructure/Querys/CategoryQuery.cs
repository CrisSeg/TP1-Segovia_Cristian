using Application.Interfaces.InterfaceCategory;
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
    public class CategoryQuery : ICategoryQuery
    {
        private readonly AppContext _context;

        public CategoryQuery(AppContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllcategories()
            => await _context.Categories.AsNoTracking().ToListAsync();
    }
}
