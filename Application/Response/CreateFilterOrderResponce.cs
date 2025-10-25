using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public record CreateFilterOrderResponce(
            long orderNumber,
            double totalAmount,
            string deliveryTo,
            string notes,
            CreateStatusOrder status,
            CreateDeliveryOrder deliveryType,
            List<CreateOrderItemResponce> orderItems,
            DateTime createdAt,
            DateTime updatedAt
        );
}
