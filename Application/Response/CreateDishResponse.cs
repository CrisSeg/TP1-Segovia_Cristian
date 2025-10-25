using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public record CreateDishResponse
    (
        Guid id,
        string name,
        string? description,
        double price,
        CreateDishCategory Category,
        string? image,
        bool isActive,
        DateTime createdAt,
        DateTime updatedAt
    );
}
