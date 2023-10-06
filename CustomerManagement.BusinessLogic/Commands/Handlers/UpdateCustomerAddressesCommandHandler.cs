using CustomerManagement.Core.Entities;
using CustomerManagement.Core.ValueObjects;
using CustomerManagement.Infrastracture.Persistence;
using MediatR;
using ShoppingCart.SharedKernel.Exceptions;
using ShoppingCart.SharedKernel.Interfaces;

namespace CustomerManagement.BusinessLogic.Commands.Handlers
{
    public class UpdateCustomerAddressesCommandHandler : IRequestHandler<UpdateCustomerAddressesCommand, Customer>
    {
        private readonly IGenericRepository<Customer, int, CustomerDbContext> _repository;

        public UpdateCustomerAddressesCommandHandler(IGenericRepository<Customer, int, CustomerDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(UpdateCustomerAddressesCommand command, CancellationToken cancellationToken)
        {
            var customerToUpdate = await _repository.GetByIdAsync(command.CustomerId);

            if (customerToUpdate is null)
            {
                throw new DomainException($"Updating addresses not successful! Not found a customer with id {command.CustomerId}");
            }

            //TODO fix this
            customerToUpdate.Addresses.Clear();
            customerToUpdate.Addresses = (ICollection<Address>)command.Addresses;

            _repository.Update(customerToUpdate);

            return customerToUpdate;
        }
    }
}
