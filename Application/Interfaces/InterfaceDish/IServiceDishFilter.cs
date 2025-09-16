using Application.DTOs;
using Application.Enums;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.InterfaceDish
{
    public interface IServiceDishFilter
    {
        Task<List<CreateDishResponse>> FilterDishesByPriceRange(string? name, int? categoryId, SortOrder orderByAsc, bool? avialable);
    }
}
