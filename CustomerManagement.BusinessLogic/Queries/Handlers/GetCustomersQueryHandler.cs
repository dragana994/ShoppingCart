using CustomerManagement.Core.Entities;
using CustomerManagement.Infrastracture.Persistence;
using MediatR;
using ShoppingCart.SharedKernel.Interfaces;

namespace CustomerManagement.BusinessLogic.Queries.Handlers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
    {
        private readonly IGenericRepository<Customer, int, CustomerDbContext> _repository;

        public GetCustomersQueryHandler(IGenericRepository<Customer, int, CustomerDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetListAsync();
        }
    }
}
