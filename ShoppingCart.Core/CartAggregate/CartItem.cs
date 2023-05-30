using Ardalis.GuardClauses;
using ShoppingCart.Core.ValueObjects;
using ShoppingCart.SharedKernel;

namespace ShoppingCart.Core.CartAggregate
{
    public class CartItem : BaseEntity<Guid>
    {
        public CartItem(Guid id, int partId, int quantity, Price price)
        {
            Id = Guard.Against.Default(id, nameof(id));
            PartId = Guard.Against.NegativeOrZero(partId);
            Quantity = quantity;
            Price = price;
        }

        public int PartId { get; private set; }
        public int Quantity { get; private set; }
        public Price Price { get; private set; }

        public override string? ToString()
        {
            return Id.ToString();
        }
    }
}
