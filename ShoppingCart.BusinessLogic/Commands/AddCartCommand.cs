using MediatR;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.BusinessLogic.Commands
{
    public class AddCartCommand : IRequest<Cart>
    {
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
    }
}
