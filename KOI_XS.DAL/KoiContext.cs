using Microsoft.EntityFrameworkCore;
using KOI_XS.DAL.Entities;
using System;

namespace KOI_XS.DAL
{
    public class KoiContext : DbContext
    {
        public KoiContext(DbContextOptions<KoiContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<KoiFish> KoiFishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderKoi> OrderKois { get; set; }
        public DbSet<Koi> Kois { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<OrderKoi>()
        .HasKey(ok => new { ok.OrderId, ok.KoiFishId });

    modelBuilder.Entity<OrderKoi>()
        .HasOne(ok => ok.Order)
        .WithMany(o => o.OrderKois)
        .HasForeignKey(ok => ok.OrderId);

    modelBuilder.Entity<OrderKoi>()
        .HasOne(ok => ok.KoiFish)
        .WithMany(k => k.OrderKois)
        .HasForeignKey(ok => ok.KoiFishId);



            
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Nguyen Van A", Email = "nguyenvana@example.com" },
                new Customer { CustomerId = 2, Name = "Tran Thi B", Email = "tranthib@example.com" }
            );

            
            modelBuilder.Entity<KoiFish>().HasData(
                new KoiFish { KoiFishId = 1, Name = "Koi Red Dragon", Color = "Red", Price = 150.00m },
                new KoiFish { KoiFishId = 2, Name = "Koi Black Beauty", Color = "Black", Price = 200.00m },
                new KoiFish { KoiFishId = 3, Name = "Koi White Pearl", Color = "White", Price = 180.00m }
            );

            
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-10) },
                new Order { OrderId = 2, CustomerId = 2, OrderDate = DateTime.Now.AddDays(-5) }
            );

            
            modelBuilder.Entity<OrderKoi>().HasData(
                new OrderKoi { OrderId = 1, KoiFishId = 1 },
                new OrderKoi { OrderId = 1, KoiFishId = 2 },
                new OrderKoi { OrderId = 2, KoiFishId = 3 }
            );
        }
    }
}
