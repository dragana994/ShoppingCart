using ShoppingCart.SharedKernel.Persistence.ValueObjects;

namespace ShoppingCart.SharedKernel.Persistence.Entities
{
    public class Store : BaseEntity<int>
    {
        public string Name { get; set; }
        public Residence Residence { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<StoreState> StoreStates { get; set; }

    }
}
