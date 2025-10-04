using Application.Exceptions;
using Application.Interfaces.InterfaceDish;
using Application.Interfaces.InterfaceOrderItem;
using Application.Interfaces.InterfacesOrder;
using Application.Response;
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
        private readonly IDishCommand dishCommand;
        private readonly IOrderItemQuery orderItemQuery;

        public ServiceDeleteDish(IDishQuery dishQuery, IDishCommand dishCommand, IOrderItemQuery orderItmeQuery)
        {
            this.dishQuery = dishQuery;
            this.dishCommand = dishCommand;
            this.orderItemQuery = orderItmeQuery;
        }

        public async Task<DeleteDishResponce> DeleteDish(Guid id)
        {
            var dish = await dishQuery.GetDishById(id);
            if (dish is null)
                throw new BadRequestException("Plato no encontrado");

            var count = await orderItemQuery.countDishByOrderItem(id);
            if (count > 0)
                throw new ConflictException("No se puede eliminar el plato porque está incluido en órdenes activas");
            else
                await dishCommand.DeleteDish(id, true);

            var categoryName = await dishQuery.GetCategoryById(dish.CategoryId) ?? string.Empty;

            return new DeleteDishResponce(
                    dish.DishId, dish.NameDish, dish.Description, dish.Price, dish.CategoryId, categoryName, dish.ImageUrl ,dish.IsDelete, dish.CreateDate, dish.UpdateDate
                );
        }
    }
}
