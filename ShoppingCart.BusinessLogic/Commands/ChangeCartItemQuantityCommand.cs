using MediatR;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.BusinessLogic.Commands
{
    public class ChangeCartItemQuantityCommand : IRequest<CartItem>
    {
        public Guid CartId { get; set; }
        public Guid CartItemId { get; set; }
        public int Quantity { get; set; }
    }
}
