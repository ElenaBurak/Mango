using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon { Id = 1, Code = "10Off", DiscountAmount = 10, MinAmount = 20, Name = "10$", Status = "Active" });
            modelBuilder.Entity<Coupon>().HasData(new Coupon { Id = 2, Code = "20Off", DiscountAmount = 20, MinAmount = 40, Name = "20$", Status = "Active" });
        }
    }
}
