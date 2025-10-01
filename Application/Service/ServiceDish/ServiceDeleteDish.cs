using Application.Exceptions;
using Application.Interfaces.InterfaceDish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.ServiceDish
{
    public class ServiceDeleteDish : IServiceDeleteDish
    {

        private readonly IDishQuery dishQuery;

        public ServiceDeleteDish(IDishQuery dishQuery)
        {
            this.dishQuery = dishQuery;
        }

        public async Task DeleteDish(Guid id)
        {
            var dish = await dishQuery.GetDishById(id);
            if (dish is null)
                throw new BadRequestException("Plato no encontrado");
        }
    }
}
