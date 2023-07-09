using ShoppingCart.SharedKernel.Persistence.ValueObjects;

namespace ShoppingCart.SharedKernel.Persistence.Entities
{
    public class CartItem : BaseEntity<Guid>
    {
        public Guid CartId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
        public Price Price { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Part Part { get; set; }
    }
}
