using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel;

namespace ShoppingCart.Core.Events
{
    public class CartItemDeletedEvent : BaseDomainEvent
    {
        public CartItemDeletedEvent(CartItem cartItem)
        {
            CartItem = cartItem;
        }

        public CartItem CartItem { get; private set; }
    }
}
