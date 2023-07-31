using AutoMapper;
using MediatR;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Commands.Handlers
{
    public class AddCartCommandHandler : IRequestHandler<AddCartCommand, Cart>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Cart, Guid> _repository;

        public AddCartCommandHandler(IMapper mapper, IGenericRepository<Cart, Guid> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Cart> Handle(AddCartCommand command, CancellationToken cancellationToken)
        {
            var cartToAdd = _mapper.Map<Cart>(command);

            await _repository.AddAsync(cartToAdd);

            return cartToAdd;
        }
    }
}
