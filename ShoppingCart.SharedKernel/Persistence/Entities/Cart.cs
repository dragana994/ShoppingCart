using ShoppingCart.SharedKernel.Persistence.Enums;

namespace ShoppingCart.SharedKernel.Persistence.Entities
{
    public class Cart : BaseEntity<Guid>
    {
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public CartStatus Status { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }

    }
}
