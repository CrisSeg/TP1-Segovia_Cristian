using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfacesOrder
{
    public interface IServiceGetOrderByID
    {
        Task<CreateFilterOrderResponce> getOrderById(long id);
    }
}
