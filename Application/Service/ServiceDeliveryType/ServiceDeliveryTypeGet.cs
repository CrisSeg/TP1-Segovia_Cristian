using Application.Interfaces.InterfaceDeliveryType;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceDeliveryType
{
    public class ServiceDeliveryTypeGet : IServiceDeliveryTypeGet
    {
        private readonly IDeliveryTypeQuery1 _deliveryTypeQuery;

        public ServiceDeliveryTypeGet(IDeliveryTypeQuery1 deliveryTypeQuery)
        {
            _deliveryTypeQuery = deliveryTypeQuery;
        }

        public async Task<List<CreateDTResponce>> GetAllDeliveryTypes()
        {
            var deliveryTypes = await _deliveryTypeQuery.GetAllDeliveryTypes();

            var response = deliveryTypes.Select(dt => new CreateDTResponce(
                IdD : dt.IdD,
                NameDeliveryT : dt.NameDeliveryT
            )).ToList();

            return response;
        }
    }
}
