using MediatR;

namespace ShoppingCart.BusinessLogic.Commands
{
    public class DeleteCartItemCommand : IRequest<Unit>
    {
        public Guid CartId { get; set; }
        public Guid CartItemId { get; set; }
    }
}
