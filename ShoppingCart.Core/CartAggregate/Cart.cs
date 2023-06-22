using Ardalis.GuardClauses;
using ShoppingCart.SharedKernel;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.Core.CartAggregate
{
    public class Cart : BaseEntity<Guid>, IAggregateRoot
    {
        public Cart(Guid id, int userId, DateTime createdDate)
        {
            Id = Guard.Against.Default(id, nameof(id));
            UserId = Guard.Against.NegativeOrZero(userId, nameof(userId));
            CreatedDate = DateTime.UtcNow;
        }

        public Cart() { }

        public int UserId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsExpired { get; private set; }
        public decimal Sum { get; private set; }


        private readonly List<CartItem> _cartItems = new();
        public IEnumerable<CartItem> Parts => _cartItems.AsReadOnly();

        public void AddItem(CartItem item)
        {

            Guard.Against.Null(item, nameof(item));
            Guard.Against.Default(item.Id, nameof(item.Id));

            _cartItems.Add(item);

            //TODO
        }

        public void DeleteItem(CartItem item)
        {
            Guard.Against.Null(item, nameof(item));

            if (_cartItems.Exists(i => i.Id == item.Id))
            {
                _cartItems.Remove(item);
            }

            //TODO
        }
    }
}
