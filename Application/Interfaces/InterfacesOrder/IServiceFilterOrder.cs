using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfacesOrder
{
    public interface IServiceFilterOrder
    {
        Task<List<CreateFilterOrderResponce>> filterOrder(DateTime? inicio, DateTime? fin, int? statusId);
    }
}
