using MediatR;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.BusinessLogic.Queries
{
    public class GetCartsByCustomerIdQuery : IRequest<IEnumerable<Cart>>
    {
        public int CustomerId { get; set; }
    }
}
