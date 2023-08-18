using MediatR;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Commands.Handlers
{
    public class ChangeCartStatusCommandHandler : IRequestHandler<ChangeCartStatusCommand, Cart>
    {
        private readonly IGenericRepository<Cart, Guid> _repository;

        public ChangeCartStatusCommandHandler(IGenericRepository<Cart, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<Cart> Handle(ChangeCartStatusCommand command, CancellationToken cancellationToken)
        {
            var cartToUpdate = await _repository.GetByIdAsync(command.Id);

            if (cartToUpdate != null)
            {
                cartToUpdate.Status = command.Status;

                //TODO add conditions
                _repository.Update(cartToUpdate);
            }

            return cartToUpdate;
        }
    }
}
