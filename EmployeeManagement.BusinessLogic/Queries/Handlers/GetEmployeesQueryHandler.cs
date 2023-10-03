using EmployeeManagement.Core.Entities;
using EmployeeManagement.Infrastracture.Persistence;
using MediatR;
using ShoppingCart.SharedKernel.Interfaces;

namespace EmployeeManagement.BusinessLogic.Queries.Handlers
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>
    {
        private readonly IGenericRepository<Employee, int, EmployeeDbContext> _repository;

        public GetEmployeesQueryHandler(IGenericRepository<Employee, int, EmployeeDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetListAsync();
        }
    }
}
