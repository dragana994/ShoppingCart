using MediatR;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.BusinessLogic.Queries
{
    public class GetCartsByEmployeeIdQuery : IRequest<IEnumerable<Cart>>
    {
        public int EmployeeId { get; set; }
    }
}
