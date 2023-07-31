using Ardalis.GuardClauses;
using ShoppingCart.Core.Enums;
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

        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; private set; }
        public CartStatus Status { get; private set; }
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
