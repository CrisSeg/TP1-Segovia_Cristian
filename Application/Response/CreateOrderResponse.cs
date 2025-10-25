using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public record CreateOrderResponse
    (
        long orderNumber,
        double totalAmount,
        DateTime createdAt
    );
}
