using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel.Specification;

namespace ShoppingCart.BusinessLogic.Specifications
{
    public class CartByCustomerIdSpecification : BaseSpecification<Cart>
    {
        public CartByCustomerIdSpecification(int customerId) : base(x => x.CustomerId == customerId) { }
    }
}
