using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Infrastracture.Specification;

namespace ShoppingCart.BusinessLogic.Specifications
{
    public class CartByEmployeeIdSpecification : BaseSpecification<Cart>
    {
        public CartByEmployeeIdSpecification(int employeeId) : base(x => x.EmployeeId == employeeId) { }
    }
}
