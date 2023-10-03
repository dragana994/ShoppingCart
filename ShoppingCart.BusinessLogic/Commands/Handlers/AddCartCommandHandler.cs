using AutoMapper;
using MediatR;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Infrastracture.Persistence;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Commands.Handlers
{
    public class AddCartCommandHandler : IRequestHandler<AddCartCommand, Cart>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Cart, Guid, ShoppingCartDbContext> _repository;

        public AddCartCommandHandler(IMapper mapper, IGenericRepository<Cart, Guid, ShoppingCartDbContext> repository)
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
