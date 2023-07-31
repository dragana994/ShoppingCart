using ShoppingCart.Core.ValueObjects;
using ShoppingCart.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Store() { }

        public string Name { get; private set; }
        public Address Address { get; private set; }

        // Parts + quantity => StoreState
        [NotMapped]
        public Dictionary<Part, int> Parts { get; private set; } = new Dictionary<Part, int>();

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
