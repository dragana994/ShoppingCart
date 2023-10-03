using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel.Specification;

namespace ShoppingCart.BusinessLogic.Specifications
{
    public class CartsByCustomerIdSpecification : BaseSpecification<Cart>
    {
        public CartsByCustomerIdSpecification(int customerId) : base(x => x.CustomerId == customerId) { }
    }
}
