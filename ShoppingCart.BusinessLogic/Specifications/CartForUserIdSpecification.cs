using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Infrastracture.Specification;

namespace ShoppingCart.BusinessLogic.Specifications
{
    public class CartForUserIdSpecification : BaseSpecification<Cart>
    {
        public CartForUserIdSpecification(int userId) : base(x => x.UserId == userId) { }
    }
}
