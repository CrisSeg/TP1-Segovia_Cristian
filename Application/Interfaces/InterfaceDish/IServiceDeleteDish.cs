using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfaceDish
{
    public interface IServiceDeleteDish
    {
        Task DeleteDish(Guid id);
    }
}
