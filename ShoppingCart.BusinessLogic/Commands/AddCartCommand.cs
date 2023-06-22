using MediatR;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.BusinessLogic.Commands
{
    public class AddCartCommand : IRequest<Cart>
    {
        public int UserId { get;  set; }
    }
}
