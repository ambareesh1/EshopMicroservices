using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext :DbContext
    {
        public DbSet<Coupon> Coupones { get; set; } =default!;


        public DiscountContext(DbContextOptions<DiscountContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, ProductName = "IPhone X", Description = "Iphone description", Amount = 800000 },
                new Coupon { Id = 2, ProductName = "Samsung 10", Description = "Samsung description", Amount = 900000 }
                );
        }
    }
}
