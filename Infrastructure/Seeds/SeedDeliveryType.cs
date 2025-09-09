using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Seeds
{
    public class SeedDeliveryType : IEntityTypeConfiguration<DeliveryType>
    {
        public void Configure(EntityTypeBuilder<DeliveryType> builder)
        {
            builder.HasData(
                new DeliveryType { IdD = 1, NameDeliveryT = "Delivery" },
                new DeliveryType { IdD = 2, NameDeliveryT = "Take away" },
                new DeliveryType { IdD = 3, NameDeliveryT = "Dine in" }
            );
        }
    }
}
