using Common.CoreEntity.Base;

namespace Inventory.Infrastructure.Entities
{
    public class Product : ExtendEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
