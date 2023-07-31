using ShoppingCart.Core.ValueObjects;
using ShoppingCart.SharedKernel;

namespace ShoppingCart.Core.Entities
{
    public class Customer : BaseEntity<int>
    {
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Customer() { }

        public string Name { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
