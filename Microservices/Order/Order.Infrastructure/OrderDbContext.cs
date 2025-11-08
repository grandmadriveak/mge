using Common.CoreEntity;
using Microsoft.EntityFrameworkCore;

namespace Order.Infrastructure
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext()
        {
            
        }
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
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
