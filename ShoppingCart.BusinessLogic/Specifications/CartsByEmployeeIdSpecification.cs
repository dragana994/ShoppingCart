using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel.Specification;

namespace ShoppingCart.BusinessLogic.Specifications
{
    public class CartsByEmployeeIdSpecification : BaseSpecification<Cart>
    {
        public CartsByEmployeeIdSpecification(int employeeId) : base(x => x.EmployeeId == employeeId) { }
    }
}
