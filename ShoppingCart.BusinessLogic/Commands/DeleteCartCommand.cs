using MediatR;

namespace ShoppingCart.BusinessLogic.Commands
{
    public class DeleteCartCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
