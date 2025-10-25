using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfaceDish
{
    public interface IServiceDeleteDish
    {
        Task<CreateDishResponse> DeleteDish(Guid id);
    }
}
