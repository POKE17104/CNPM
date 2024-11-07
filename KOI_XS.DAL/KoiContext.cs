
using Microsoft.EntityFrameworkCore;
using KOI_XS.DAL.Entities;
using System;
using System.Collections.Generic;

namespace KOI_XS.DAL
{
    public class KoiContext : DbContext
    {
        public KoiContext(DbContextOptions<KoiContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<KoiFish> KoiFishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderKoi> OrderKois { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Thiết lập khóa chính cho bảng trung gian
            modelBuilder.Entity<OrderKoi>()
                .HasKey(ok => new { ok.OrderId, ok.KoiFishId });

            // Thiết lập mối quan hệ nhiều-nhiều giữa Orders và KoiFishes
            modelBuilder.Entity<OrderKoi>()
                .HasOne(ok => ok.Order)
                .WithMany(o => o.OrderKois)
                .HasForeignKey(ok => ok.OrderId);

            modelBuilder.Entity<OrderKoi>()
                .HasOne(ok => ok.KoiFish)
                .WithMany(k => k.OrderKois)
                .HasForeignKey(ok => ok.KoiFishId);

            // Seed dữ liệu mẫu cho Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Nguyen Van A", Email = "nguyenvana@example.com" },
                new Customer { CustomerId = 2, Name = "Tran Thi B", Email = "tranthib@example.com" }
            );

            // Seed dữ liệu mẫu cho KoiFishes
            modelBuilder.Entity<KoiFish>().HasData(
                new KoiFish { KoiFishId = 1, Name = "Koi Red Dragon", Color = "Red", Price = 150.00m },
                new KoiFish { KoiFishId = 2, Name = "Koi Black Beauty", Color = "Black", Price = 200.00m },
                new KoiFish { KoiFishId = 3, Name = "Koi White Pearl", Color = "White", Price = 180.00m }
            );

            // Seed dữ liệu mẫu cho Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-10) },
                new Order { OrderId = 2, CustomerId = 2, OrderDate = DateTime.Now.AddDays(-5) }
            );

            // Seed dữ liệu mẫu cho OrderKois (bảng trung gian)
            modelBuilder.Entity<OrderKoi>().HasData(
                new OrderKoi { OrderId = 1, KoiFishId = 1 },
                new OrderKoi { OrderId = 1, KoiFishId = 2 },
                new OrderKoi { OrderId = 2, KoiFishId = 3 }
            );
        }
    }
}
