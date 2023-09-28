using ShoppingCart.SharedKernel.Persistence.ValueObjects;

namespace ShoppingCart.SharedKernel.Persistence.Entities
{
    public class Part : BaseEntity<int>
    {
        public string Name { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Price Price { get; set; }

        public virtual ICollection<StorePart> StoreStates { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
