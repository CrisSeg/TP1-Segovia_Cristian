using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public record DeleteDishResponce(
        Guid DishId,
        string Name,
        string? Description,
        double Price,
        int CategoryId,
        string CategoryName,
        string? ImageUrl,
        bool isActive,
        DateTime CreateDate,
        DateTime UpdateDate
    );
}
