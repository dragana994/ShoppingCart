using AutoMapper;
using MediatR;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.BusinessLogic.Commands.Handlers
{
    public class AddCartCommandHandler : IRequestHandler<AddCartCommand, Cart>
    {
        private readonly IMapper _mapper;

        public AddCartCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Cart> Handle(AddCartCommand command, CancellationToken cancellationToken)
        {
            var cartToAdd = _mapper.Map<Cart>(command);

            return cartToAdd;
        }
    }
}
