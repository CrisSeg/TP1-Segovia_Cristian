using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seeds
{
    public class SeedStatus : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData(
                new Status { Id = 1, NameStatus = "Pending" },
                new Status { Id = 2, NameStatus = "In Progress" },
                new Status { Id = 3, NameStatus = "Ready" },
                new Status { Id = 4, NameStatus = "Delivery" },
                new Status { Id = 5, NameStatus = "Delivered" },
                new Status { Id = 6, NameStatus = "Closed" }
            );
        }
    }
}
