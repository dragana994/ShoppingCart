using AutoMapper;
using MediatR;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Core.Exceptions;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Commands.Handlers
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Cart, Guid> _cartRepository;

        public DeleteCartItemCommandHandler(IMapper mapper, IGenericRepository<Cart, Guid> cartRepository)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(DeleteCartItemCommand command, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(command.CartId);

            if (cart == null)
            {
                throw new DomainException($"Deleting cart item not successful! Not found a cart with id {command.CartId}");
            }

            var cartItem = cart.CartItems.FirstOrDefault(x => x.Id.Equals(command.CartId));

            if (cartItem == null)
            {
                throw new DomainException($"Deleting cart item not successful! Not found a cart item with id {command.CartItemId} in the cart.");
            }

            cart.DeleteItem(cartItem);

            _cartRepository.Update(cart);

            return Unit.Value;
        }
    }
}
