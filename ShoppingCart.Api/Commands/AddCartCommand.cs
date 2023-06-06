using MediatR;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.Api.Commands
{
    public class AddCartCommand : IRequest<Guid>
    {
        public int UserId { get; private set; }
    }
}
