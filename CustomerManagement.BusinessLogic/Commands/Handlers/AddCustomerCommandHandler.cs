using AutoMapper;
using CustomerManagement.Core.Entities;
using CustomerManagement.Infrastracture.Persistence;
using MediatR;
using ShoppingCart.SharedKernel.Interfaces;

namespace CustomerManagement.BusinessLogic.Commands.Handlers
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Customer>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Customer, int, CustomerDbContext> _repository;

        public AddCustomerCommandHandler(IMapper mapper, IGenericRepository<Customer, int, CustomerDbContext> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Customer> Handle(AddCustomerCommand command, CancellationToken cancellationToken)
        {
            var customerToAdd = _mapper.Map<Customer>(command);
            await _repository.AddAsync(customerToAdd);

            return customerToAdd;
        }
    }
}
