using AutoMapper;
using MediatR;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Core.Exceptions;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Commands.Handlers
{
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, CartItem>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Cart, Guid> _cartRepository;

        public AddCartItemCommandHandler(IMapper mapper, IGenericRepository<Cart, Guid> cartRepository)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
        }

        public async Task<CartItem> Handle(AddCartItemCommand command, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(command.CartId);

            if (cart == null)
            {
                throw new DomainException($"Adding cart item not successful! Not found a cart with id {command.CartId}");
            }

            var cartItemToAdd = _mapper.Map<CartItem>(command);
            cart.AddItem(cartItemToAdd);
            _cartRepository.Update(cart);

            return cartItemToAdd;
        }
    }
}
