using MediatR;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Commands.Handlers
{
    public class ChangeCartItemQuantityCommandHandler : IRequestHandler<ChangeCartItemQuantityCommand, CartItem>
    {
        private readonly IGenericRepository<Cart, Guid> _cartRepository;

        public ChangeCartItemQuantityCommandHandler(IGenericRepository<Cart, Guid> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartItem> Handle(ChangeCartItemQuantityCommand command, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(command.CartId);

            if (cart == null)
                throw new Exception(); //TODO

            var cartItem = cart.CartItems.FirstOrDefault(x => x.Id.Equals(command.CartItemId));

            if (cartItem == null)
                throw new Exception(); //TODO

            cartItem.UpdateQuantity(command.Quantity);

            _cartRepository.Update(cart);

            return cartItem;

        }
    }
}
