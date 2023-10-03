using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel.Specification;

namespace ShoppingCart.BusinessLogic.Specifications
{
    public class CartItemsByCartIdSpecification : BaseSpecification<CartItem>
    {
        public CartItemsByCartIdSpecification(Guid cartId) : base(x => x.CartId == cartId) { }
    }
}
