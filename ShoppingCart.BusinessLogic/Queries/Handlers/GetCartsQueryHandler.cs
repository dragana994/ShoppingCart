using MediatR;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.BusinessLogic.Queries.Handlers
{
    public class GetCartsQueryHandler : IRequestHandler<GetCartsQuery, IEnumerable<Cart>>
    {
        public Task<IEnumerable<Cart>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
