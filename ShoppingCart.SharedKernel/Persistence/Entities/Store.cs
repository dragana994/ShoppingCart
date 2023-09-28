using ShoppingCart.SharedKernel.Persistence.ValueObjects;

namespace ShoppingCart.SharedKernel.Persistence.Entities
{
    public class Store : BaseEntity<int>
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<StorePart> StoreStates { get; set; }

    }
}
