using Domain.Entities;
using Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppContext: DbContext
    {
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<DeliveryType> Deliverytypes => Set<DeliveryType>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Dish> Dishes => Set<Dish>();
        public DbSet<OrderItem> orderItems => Set<OrderItem>();
        public DbSet<Status> Statuses => Set<Status>();

        public AppContext(DbContextOptions<AppContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Al insertar un dish la flag de isActive es true
            modelBuilder.Entity<Dish>().Property(d => d.IsDelete).HasDefaultValue(false);
            // Oculta los dish que tengan isActive false no se muestren
            modelBuilder.Entity<Dish>().HasQueryFilter(d => !d.IsDelete);


            base.OnModelCreating(modelBuilder);

            //Entidad Dish
            modelBuilder.Entity<Dish>().HasKey(d => d.DishId);
            modelBuilder.Entity<Dish>().Property(d => d.DishId).IsRequired();
            modelBuilder.Entity<Dish>().Property(d => d.NameDish).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Dish>().Property(d => d.Description).IsRequired().HasMaxLength(1000);
            modelBuilder.Entity<Dish>().Property(d => d.Price).IsRequired().HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Dish>().Property(d => d.Avialable).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<Dish>().Property(d => d.ImageUrl).IsRequired().HasMaxLength(2083);
            modelBuilder.Entity<Dish>().Property(d => d.CreateDate).IsRequired();
            modelBuilder.Entity<Dish>().Property(d => d.UpdateDate).IsRequired();

            //FK Relacion N-1 de Dish con Category
            modelBuilder.Entity<Dish>()
                .HasOne(d => d.Category)
                .WithMany((Category c) => c.Dishes)
                .HasForeignKey(d => d.CategoryId);

            //Entidad Category
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Id).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.NameCategory).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Category>().Property(c => c.Description).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Category>().Property(c => c.Order).IsRequired();

            //Entidad OrderItem
            modelBuilder.Entity<OrderItem>().HasKey(oi => oi.OrderItemId);
            modelBuilder.Entity<OrderItem>().Property(oi => oi.OrderItemId).IsRequired();
            modelBuilder.Entity<OrderItem>().Property(oi => oi.Quantity).IsRequired();
            modelBuilder.Entity<OrderItem>().Property(oi => oi.Notes).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<OrderItem>().Property(oi => oi.CreateDate).IsRequired();

            //FK Relacion Dish con OrderItem N-1
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Dish)
                .WithMany((Dish d) => d.OrderItems)
                .HasForeignKey(oi => oi.DishId);

            //Entidad Order
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Order>().Property(o => o.OrderId).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.DeliveryTo).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Order>().Property(o => o.Notes).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Order>().Property(o => o.Price).IsRequired().HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Order>().Property(o => o.CreateDate).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.UpdateDate).IsRequired();

            //Fk Relacion OrderItem con Order  N-1
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany((Order o) => o.OrderItemsO)
                .HasForeignKey(oi => oi.OrderId);

            //Entidad Status
            modelBuilder.Entity<Status>().HasKey(s => s.Id);
            modelBuilder.Entity<Status>().Property(s => s.Id).IsRequired();
            modelBuilder.Entity<Status>().Property(s => s.NameStatus).IsRequired().HasMaxLength(25);

            //Fk Relacion OrderItem con Status N-1
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Status)
                .WithMany((Status s) => s.SOrderItems)
                .HasForeignKey(oi => oi.StatusId);

            //FK Order con Status N-1
            modelBuilder.Entity<Order>()
                .HasOne(o => o.OverallStatus)
                .WithMany((Status s) => s.SOrders)
                .HasForeignKey(o => o.OStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            //Entidad DeliveryType
            modelBuilder.Entity<DeliveryType>().HasKey(dt => dt.IdD);
            modelBuilder.Entity<DeliveryType>().Property(dt => dt.IdD).IsRequired();
            modelBuilder.Entity<DeliveryType>().Property(dt => dt.NameDeliveryT).IsRequired().HasMaxLength(25);

            //Fk Relacion Order con DeliveryType N-1
            modelBuilder.Entity<Order>()
                .HasOne(o => o.deliveryType)
                .WithMany((DeliveryType dt) => dt.Orders)
                .HasForeignKey(o => o.DeliveryTypeId);

            modelBuilder.ApplyConfiguration(new SeedCategory());
            modelBuilder.ApplyConfiguration(new SeedStatus());
            modelBuilder.ApplyConfiguration(new SeedDeliveryType());
        }
    }
}
