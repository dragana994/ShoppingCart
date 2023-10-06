using CustomerManagement.Core.Entities;
using CustomerManagement.Core.ValueObjects;
using CustomerManagement.Infrastracture.Persistence;
using MediatR;
using ShoppingCart.SharedKernel.Interfaces;

namespace CustomerManagement.BusinessLogic.Queries.Handlers
{
    public class GetCustomerAddressesQueryHandler : IRequestHandler<GetCustomerAddressesQuery, IEnumerable<Address>>
    {
        private readonly IGenericRepository<Customer, int, CustomerDbContext> _repository;

        public GetCustomerAddressesQueryHandler(IGenericRepository<Customer, int, CustomerDbContext> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Address>> Handle(GetCustomerAddressesQuery request, CancellationToken cancellationToken)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
