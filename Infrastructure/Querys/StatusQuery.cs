using Application.Interfaces.InterfaceStatus;
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
    public class StatusQuery : IStatusQuery
    {
        private readonly AppContext _context;

        public StatusQuery(AppContext context)
        {
            _context = context;
        }

        public async Task<List<Status>> GetAllStatuses()
            => await _context.Statuses.AsNoTracking().ToListAsync();
    }
}
