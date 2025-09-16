using Application.Interfaces.InterfaceDeliveryType;
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
    public class DeliveryTypeQuery : IDeliveryTypeQuery1
    {
        private readonly AppContext _context;

        public DeliveryTypeQuery(AppContext context)
        {
            _context = context;
        }

        public async Task<List<DeliveryType>> GetAllDeliveryTypes()
            => await _context.Deliverytypes.AsNoTracking().ToListAsync();
    }
}
