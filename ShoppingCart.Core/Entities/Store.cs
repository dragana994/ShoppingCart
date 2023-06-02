using ShoppingCart.Core.ValueObjects;
using ShoppingCart.SharedKernel;

namespace ShoppingCart.Core.Entities
{
    public class Store : BaseEntity<int>
    {
        public Store(int id, string name, Address address)
        {
            Id = id;
            Name = name;
            Parts = new Dictionary<Part, int>();
            Address = address;
        }

        public string Name { get; private set; }
        public Address Address { get; private set; }

        // Parts + quantity
        public Dictionary<Part, int> Parts { get; private set; } = new Dictionary<Part, int>();

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
