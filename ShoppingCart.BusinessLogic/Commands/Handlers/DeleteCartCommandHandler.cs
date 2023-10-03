using AutoMapper;
using MediatR;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Core.Enums;
using ShoppingCart.Infrastracture.Persistence;
using ShoppingCart.SharedKernel.Exceptions;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Commands.Handlers
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Cart, Guid, ShoppingCartDbContext> _repository;

        public DeleteCartCommandHandler(IMapper mapper, IGenericRepository<Cart, Guid, ShoppingCartDbContext> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
        {
            var cartToDelete = await _repository.GetByIdAsync(command.Id);

            if (cartToDelete == null)
            {
                throw new DomainException($"Deleting cart not sucessful! Not found a cart with id {command.Id}");
            }

            if (cartToDelete.Status != CartStatus.Created)
            {
                throw new DomainException($"Deleting cart not sucessful! Cart is already in process.");
            }

            _repository.Delete(cartToDelete);

            return Unit.Value;
        }
    }
}
