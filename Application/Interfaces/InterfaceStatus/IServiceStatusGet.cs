using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfaceStatus
{
    public interface IServiceStatusGet
    {
        Task<List<CreateStatusResponce>> GetAllStatuses();
    }
}
