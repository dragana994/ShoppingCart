using AutoMapper;
using MediatR;
using ShoppingCart.Core.CartAggregate;
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

        public async Task<Unit> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(request.CartId);

            //TODO add conditions when is OK to delete cart
            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(x=>x.Id.Equals(request.CartId));

                if (cartItem != null)
                {
                    cart.DeleteItem(cartItem);

                    _cartRepository.Update(cart);
                }

                //TODO Handle Null error
            }

            return Unit.Value;
        }
    }
}
