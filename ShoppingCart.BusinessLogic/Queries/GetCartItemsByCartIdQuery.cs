using MediatR;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.BusinessLogic.Queries
{
    public class GetCartItemsByCartIdQuery : IRequest<IEnumerable<CartItem>>
    {
        public Guid CartId { get; set; }
    }
}
