using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public record CreateOrderItemResponce(
            long orderItemId,
            int quantity,
            string notes,
            int oStatusId,
            string oStatus,
            Guid oDishId,
            string oDishName,
            string oDishImage
        );
}
