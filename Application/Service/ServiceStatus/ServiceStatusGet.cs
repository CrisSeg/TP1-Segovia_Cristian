using Application.Interfaces.InterfaceStatus;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceStatus
{
    public class ServiceStatusGet : IServiceStatusGet
    {
        public readonly IStatusQuery _statusQuery;

        public ServiceStatusGet(IStatusQuery statusQuery)
        {
            _statusQuery = statusQuery;
        }

        public async Task<List<CreateStatusResponce>> GetAllStatuses()
        {
            var statuses = await _statusQuery.GetAllStatuses();

            var responce = statuses.Select(s => new CreateStatusResponce
            (
                id : s.Id,
                name : s.NameStatus
            )).ToList();

            return responce;
        }   
    }
}
