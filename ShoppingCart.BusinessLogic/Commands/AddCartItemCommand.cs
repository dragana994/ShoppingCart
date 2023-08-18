using MediatR;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.BusinessLogic.Commands
{
    public class AddCartItemCommand : IRequest<CartItem>
    {
        public Guid CartId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
    }
}
