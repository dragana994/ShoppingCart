using MediatR;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.BusinessLogic.Queries
{
    public class GetCartByIdQuery : IRequest<Cart>
    {
        public Guid Id { get; set; }
    }
}
