using EmployeeManagement.Core.Enums;
using ShoppingCart.SharedKernel;

namespace EmployeeManagement.Core.Entities
{
    //TODO sholud thios be aggregate in this context
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
        public EmployeeStatus Status { get; set; }

        public void ChangeStatus(EmployeeStatus newStatus)
        {
            Status = newStatus;
        }
    }
}
