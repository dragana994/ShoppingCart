using MediatR;
using ShoppingCart.Api.Commands;

namespace ShoppingCart.Api.Handlers
{
    public class AddCartHandler : IRequestHandler<AddCartCommand, Guid>
    {
        public async Task<Guid> Handle(AddCartCommand request, CancellationToken cancellationToken)
        {
            return Guid.NewGuid();
        }
    }
}
