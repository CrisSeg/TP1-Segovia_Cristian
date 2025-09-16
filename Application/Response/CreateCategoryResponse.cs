using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public record CreateCategoryResponse
    (
        int Id,
        string NameCategory,
        string Description,
        int Order
    );
}
