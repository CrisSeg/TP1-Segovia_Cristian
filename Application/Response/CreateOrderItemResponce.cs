using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public record CreateOrderItemResponce(
            long id,
            int quantity,
            string notes,
            CreateOIStatus status,
            CreateOIDish dish
        );

    public record CreateOIStatus(
            int id,
            string name
        );

    public record CreateOIDish(
            Guid id,
            string name,
            string image
        );
}
