using EmployeeManagement.BusinessLogic.Specifications;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Infrastracture.Persistence;
using MediatR;
using ShoppingCart.SharedKernel.Interfaces;

namespace EmployeeManagement.BusinessLogic.Queries.Handlers
{
    public class GetEmployeesByStoreIdQueryHanlder : IRequestHandler<GetEmployeesByStoreIdQuery, IEnumerable<Employee>>
    {
        private readonly IGenericRepository<Employee, int, EmployeeDbContext> _repository;

        public GetEmployeesByStoreIdQueryHanlder(IGenericRepository<Employee, int, EmployeeDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> Handle(GetEmployeesByStoreIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new EmployeesByStoreIdSpecification(request.StoreId);
            var employees = await _repository.GetListAsync(specification);

            return employees;
        }
    }
}
