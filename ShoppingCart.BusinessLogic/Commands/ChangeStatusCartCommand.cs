using MediatR;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Core.Enums;

namespace ShoppingCart.BusinessLogic.Commands
{
    public class ChangeCartStatusCommand : IRequest<Cart>
    {
        public Guid Id { get; set; }
        public CartStatus Status { get; set; }
    }
}
