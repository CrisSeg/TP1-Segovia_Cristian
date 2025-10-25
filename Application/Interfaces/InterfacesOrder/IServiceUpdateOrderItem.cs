using Application.DTOs;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfacesOrder
{
    public interface IServiceUpdateOrderItem
    {
        Task<UpdateOrderByItemResponse> updateOrderItemList(long id, List<CreateOrderItemRequest> items);
    }
}
