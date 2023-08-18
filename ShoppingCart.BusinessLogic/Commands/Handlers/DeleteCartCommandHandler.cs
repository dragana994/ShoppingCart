using AutoMapper;
using MediatR;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Commands.Handlers
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Cart, Guid> _repository;

        public DeleteCartCommandHandler(IMapper mapper, IGenericRepository<Cart, Guid> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cartToDelete = await _repository.GetByIdAsync(request.Id);

            //TODO add conditions when is OK to delete cart
            if (cartToDelete != null)
            {
                _repository.Delete(cartToDelete);
            }

            return Unit.Value;
        }
    }
}
