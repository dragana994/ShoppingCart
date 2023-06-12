using MediatR;

namespace ShoppingCart.BusinessLogic.Commands
{
    public class AddCartCommand : IRequest<Guid>
    {
        public int UserId { get; private set; }
    }
}
