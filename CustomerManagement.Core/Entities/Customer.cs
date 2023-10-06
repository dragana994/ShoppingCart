using CustomerManagement.Core.ValueObjects;
using ShoppingCart.SharedKernel;

namespace CustomerManagement.Core.Entities
{
    public class Customer : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
