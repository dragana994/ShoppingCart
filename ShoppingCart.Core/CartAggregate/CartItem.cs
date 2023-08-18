using Ardalis.GuardClauses;
using ShoppingCart.Core.ValueObjects;
using ShoppingCart.SharedKernel;

namespace ShoppingCart.Core.CartAggregate
{
    public class CartItem : BaseEntity<Guid>
    {
        public CartItem(Guid id, int partId, int quantity)
        {
            Id = Guard.Against.Default(id, nameof(id));
            PartId = Guard.Against.NegativeOrZero(partId, nameof(partId));
            Quantity = Guard.Against.NegativeOrZero(quantity, nameof(quantity));
        }

        public CartItem() { }

        public Guid CartId { get; private set; }
        public int PartId { get; private set; }
        public int Quantity { get; private set; }
        public Price Price { get; private set; }

        public void UpdateQuantity(int newQunatity)
        {
            Guard.Against.NegativeOrZero(newQunatity, nameof(newQunatity));

            if (newQunatity == Quantity) return;

            Quantity = newQunatity;

            //TODO add logic to take a price from part

            //TODO
        }
    }
}
