using ShoppingCart.Core.Entities;
using ShoppingCart.SharedKernel;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.Core.CartAggregate
{
    public class Cart : BaseEntity<Guid>, IAggregateRoot
    {
        public int UserId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsExpired { get; private set; }
        public decimal Sum { get; private set; }

        private readonly List<CartItem> _cartItems = new();
        public IEnumerable<CartItem> Parts => _cartItems.AsReadOnly();

        public void AddItem(CartItem item) { }
        public void RemoveItem(CartItem item) { }
    }
}
