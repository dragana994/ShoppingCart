using MediatR;

namespace ShoppingCart.BusinessLogic.Commands.Handlers
{
    public class AddCartCommandHandler : IRequestHandler<AddCartCommand, Guid>
    {
        public async Task<Guid> Handle(AddCartCommand request, CancellationToken cancellationToken)
        {
            return Guid.NewGuid();
        }
    }
}
