using Common.CoreEntity;
using Microsoft.EntityFrameworkCore;

namespace Shipping.Infrastructure
{
    public class ShippingDbContext : DbContext
    {
        public ShippingDbContext(DbContextOptions<ShippingDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyCommonEntityConfiguration();
        }
    }
}
