using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfaceOrderItem
{
    public interface IOrderItemQuery
    {
        Task<string?> getStatusId(int id);
        Task<string?> getDishId(Guid id);
        Task<string?> getDishImage(Guid id);
    }
}
