using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfaceDeliveryType
{
    public interface IDeliveryTypeQuery1
    {
        Task<List<DeliveryType>> GetAllDeliveryTypes();
    }
}
