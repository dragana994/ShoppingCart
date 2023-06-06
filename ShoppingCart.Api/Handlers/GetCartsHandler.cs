using MediatR;
using ShoppingCart.Api.Queries;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.Api.Handlers
{
    public class GetCartsHandler : IRequestHandler<GetCartsQuery, IEnumerable<Cart>>
    {
        public Task<IEnumerable<Cart>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
