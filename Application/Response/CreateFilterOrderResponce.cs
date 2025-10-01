using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public record CreateFilterOrderResponce(
            long orderId,
            double price,
            string deliveryTo,
            string notes,
            int statusId,
            string status,
            int deliveryId,
            string deliveryType,
            List<CreateOrderItemResponce> orderItems,
            DateTime createDate,
            DateTime updateDate
        );
}
