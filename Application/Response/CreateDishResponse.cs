using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public record CreateDishResponse
    (
        Guid DishId,
        string Name,
        string? Description,
        double Price,
        bool Avialable,
        string? ImageUrl,
        DateTime CreateDate,
        DateTime UpdateDate,
        int CategoryId,
        string CategoryName
    );
}
