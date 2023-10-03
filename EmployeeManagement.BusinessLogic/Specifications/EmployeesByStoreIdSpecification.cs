using EmployeeManagement.Core.Entities;
using ShoppingCart.SharedKernel.Specification;

namespace EmployeeManagement.BusinessLogic.Specifications
{
    public class EmployeesByStoreIdSpecification : BaseSpecification<Employee>
    {
        public EmployeesByStoreIdSpecification(int storeId) : base(x => x.StoreId == storeId) { }
    }
}
