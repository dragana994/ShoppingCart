using CustomerManagement.Core.Entities;
using CustomerManagement.Infrastracture.Persistence;
using MediatR;
using ShoppingCart.SharedKernel.Exceptions;
using ShoppingCart.SharedKernel.Interfaces;

namespace CustomerManagement.BusinessLogic.Commands.Handlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly IGenericRepository<Customer, int, CustomerDbContext> _repository;

        public DeleteCustomerCommandHandler(IGenericRepository<Customer, int, CustomerDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var customerToDelete = await _repository.GetByIdAsync(command.Id);

            if (customerToDelete is null)
            {
                throw new DomainException($"Deleting customer not sucessful! Not found a customer with id {command.Id}");
            }

            //Add rules - it's not able to delete if there is cart on this customer

            _repository.Delete(customerToDelete);

            return Unit.Value;
        }
    }
}
