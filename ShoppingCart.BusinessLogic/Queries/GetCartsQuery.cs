using MediatR;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.BusinessLogic.Queries
{
    public class GetCartsQuery : IRequest<IEnumerable<Cart>>
    {
    }
}
