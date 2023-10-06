using CustomerManagement.Core.Entities;
using CustomerManagement.Infrastracture.Persistence;
using MediatR;
using ShoppingCart.SharedKernel.Interfaces;

namespace CustomerManagement.BusinessLogic.Queries.Handlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly IGenericRepository<Customer, int, CustomerDbContext> _repository;

        public GetCustomerByIdQueryHandler(IGenericRepository<Customer, int, CustomerDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id);

            return customer;
        }
    }
}
