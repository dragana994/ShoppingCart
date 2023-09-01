using Ardalis.GuardClauses;
using ShoppingCart.Core.CartAggregate.Guards;
using ShoppingCart.Core.Enums;
using ShoppingCart.Core.Events;
using ShoppingCart.SharedKernel;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.Core.CartAggregate
{
    public class Cart : BaseEntity<Guid>, IAggregateRoot
    {
        public Cart(Guid id, int employeeId, int customerId)
        {
            Id = Guard.Against.Default(id, nameof(id));
            EmployeeId = Guard.Against.NegativeOrZero(employeeId, nameof(employeeId));
            CustomerId = Guard.Against.NegativeOrZero(customerId, nameof(customerId));

            CreatedDate = DateTime.UtcNow;
            Status = CartStatus.Created;
        }

        public Cart(int employeeId, int customerId)
        {
            Id = Guid.NewGuid();

            EmployeeId = Guard.Against.NegativeOrZero(employeeId, nameof(employeeId));
            CustomerId = Guard.Against.NegativeOrZero(customerId, nameof(customerId));

            CreatedDate = DateTime.UtcNow;
            Status = CartStatus.Created;
        }

        public Cart() { }

        public int EmployeeId { get; private set; }
        public int CustomerId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public CartStatus Status { get; private set; }

        private readonly List<CartItem> _cartItems = new();
        public IEnumerable<CartItem> CartItems => _cartItems.AsReadOnly();

        public void AddItem(CartItem item)
        {
            Guard.Against.Null(item, nameof(item));
            Guard.Against.Default(item.Id, nameof(item.Id));
            Guard.Against.DuplicateCartItem(_cartItems, item);

            _cartItems.Add(item);

            Events.Add(new CartItemAddedEvent(item));
        }

        public void DeleteItem(CartItem item)
        {
            Guard.Against.Null(item, nameof(item));
            Guard.Against.NotFoundCartItem(_cartItems, item);

            _cartItems.Remove(item);

            Events.Add(new CartItemDeletedEvent(item));
        }

        public void ChangeStatus(CartStatus newStatus)
        {
            Guard.Against.ValidStatusChange(Status, newStatus);

            Status = newStatus;
        }
    }
}
