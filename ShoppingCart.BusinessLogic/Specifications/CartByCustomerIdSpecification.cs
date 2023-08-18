using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Infrastracture.Specification;

namespace ShoppingCart.BusinessLogic.Specifications
{
    public class CartByCustomerIdSpecification : BaseSpecification<Cart>
    {
        public CartByCustomerIdSpecification(int customerId) : base(x => x.CustomerId == customerId) { }
    }
}
