using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel;

namespace ShoppingCart.Core.Events
{
    public class CartItemAddedEvent : BaseDomainEvent
    {
        public CartItemAddedEvent(CartItem cartItem)
        {
            CartItem = cartItem;
        }

        public CartItem CartItem { get; private set; }
    }
}
