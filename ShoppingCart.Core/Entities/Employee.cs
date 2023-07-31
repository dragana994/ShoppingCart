using ShoppingCart.SharedKernel;

namespace ShoppingCart.Core.Entities
{
    public class Employee : BaseEntity<int>
    {
        public Employee(int id, string name, int storeId)
        {
            Id = id;
            Name = name;
            StoreId = storeId;
        }

        public Employee() { }

        public string Name { get; set; }
        public int StoreId { get; set; }
    }
}
