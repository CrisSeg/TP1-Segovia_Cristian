using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfacesOrder
{
    public interface IOrderQuery
    {
        Task<List<Order>> getAll();
        Task<string?> getStatusById(int id);
        Task<string?> getDeliveryTipeId(int id);
    }
}
