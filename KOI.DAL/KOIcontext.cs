using Microsoft.EntityFrameworkCore;
using KOI.DAL.Models;

namespace KOI.DAL.Data
{
    public class KOIcontext : DbContext
    {
        public KOIcontext(DbContextOptions<KOIcontext> options)
            : base(options)
        {
        }

        public DbSet<Fish> Fish { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.FishId });

        }
    }
}
