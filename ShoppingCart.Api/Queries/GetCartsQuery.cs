using MediatR;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.Api.Queries
{
    public class GetCartsQuery : IRequest<IEnumerable<Cart>>
    {
    }
}
