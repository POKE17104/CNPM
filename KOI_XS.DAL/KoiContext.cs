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
                new Customer { CustomerId = 1, Name = "Nguyen Van A", Email = "nguyenvana@example.com", Address = "123/34 Lê Văn Thọ, p15, Gò vấp,TP-HCM", Username = "nguyenvana", Password = "password123", PhoneNumber = "0123456789" },
                new Customer { CustomerId = 2, Name = "Tran Thi B", Email = "tranthib@example.com", Address = "456 Nguyễn Thị Minh Khai,p1,Quận 1, Tp-HCM", Username = "tranthib", Password = "password456", PhoneNumber = "0987654321" }
            );

            // Seed data cho KoiFish
            modelBuilder.Entity<KoiFish>().HasData(
                new KoiFish { KoiFishId = 1, Name = "Koi Red Dragon", Color = "Red", Price = 150.00m, Breed = "Dragon", ImageUrl = "http://example.com/koi-red-dragon.jpg" },
                new KoiFish { KoiFishId = 2, Name = "Koi Black Beauty", Color = "Black", Price = 200.00m, Breed = "Beauty", ImageUrl = "http://example.com/koi-black-beauty.jpg" },
                new KoiFish { KoiFishId = 3, Name = "Koi White Pearl", Color = "White", Price = 180.00m, Breed = "Pearl", ImageUrl = "http://example.com/koi-white-pearl.jpg" }
            );

            // Seed data cho Order
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-10) },
                new Order { OrderId = 2, CustomerId = 2, OrderDate = DateTime.Now.AddDays(-5) }
            );

            // Seed data cho OrderKoi
            modelBuilder.Entity<OrderKoi>().HasData(
                new OrderKoi { OrderId = 1, KoiFishId = 1, Quantity = 1, UnitPrice = 150.00m },
                new OrderKoi { OrderId = 1, KoiFishId = 2, Quantity = 1, UnitPrice = 200.00m },
                new OrderKoi { OrderId = 2, KoiFishId = 3, Quantity = 1, UnitPrice = 180.00m }
            );
        }
    }
}
