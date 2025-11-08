using Microsoft.EntityFrameworkCore;

namespace Inventory.Services
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext()
        {

        }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
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
