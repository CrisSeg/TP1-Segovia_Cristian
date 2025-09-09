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
    public class SeedCategory : IEntityTypeConfiguration<Category> 
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, NameCategory = "Entradas", Description = "Pequeñas porcines para abrir el apetito antes del plato principal.", Order = 1 },
                new Category { Id = 2, NameCategory = "Ensaladas", Description = "Opciones frescas y livianas, ideales como acompañamiento o plato principal.", Order = 2 },
                new Category { Id = 3, NameCategory = "Minutas", Description = "Platos rápidos y clásicos de bodegón: milanesas, torillas, revueltos.", Order = 3 },
                new Category { Id = 4, NameCategory = "Pastas", Description = "Vareidad de pastas caseras y salsas tradicinales.", Order = 4 },
                new Category { Id = 5, NameCategory = "Parrilla", Description = "Cortes de carne asados a la parrilla, servidos con guarnicion.", Order = 5 },
                new Category { Id = 6, NameCategory = "Pizzas", Description = "Pizzas artesanales con masa casera y variedad de ingredientes.", Order = 6 },
                new Category { Id = 7, NameCategory = "Sandwiches", Description = "Sandwiches y lomitos completos preparados al momento.", Order = 7 },
                new Category { Id = 8, NameCategory = "Bebidas", Description = "Gaseosas, jugos, aguas  y opciones sin alcohol.", Order = 8 },
                new Category { Id = 9, NameCategory = "Cervezas Artesanales", Description = "Cervezas de produccion artesanal, rubias, rojas, negras.", Order = 9 },
                new Category { Id = 10, NameCategory = "Postres", Description = "Dulces tentaciones para finalizar la comida con broche de oro.", Order = 10 }
            );
        }
    }
}
