using MediatR;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Infrastracture.Persistence;
using ShoppingCart.SharedKernel.Exceptions;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Commands.Handlers
{
    public class ChangeCartStatusCommandHandler : IRequestHandler<ChangeCartStatusCommand, Cart>
    {
        private readonly IGenericRepository<Cart, Guid, ShoppingCartDbContext> _repository;

        public ChangeCartStatusCommandHandler(IGenericRepository<Cart, Guid, ShoppingCartDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<Cart> Handle(ChangeCartStatusCommand command, CancellationToken cancellationToken)
        {
            var cartToUpdate = await _repository.GetByIdAsync(command.Id);

            if (cartToUpdate == null)
            {
                throw new DomainException($"Changing status not sucessful! Not found a cart with id {command.Id}");
            }

            cartToUpdate.ChangeStatus(command.Status);

            _repository.Update(cartToUpdate);

            return cartToUpdate;
        }
    }
}
