using EmployeeManagement.Core.Entities;
using EmployeeManagement.Infrastracture.Persistence;
using MediatR;
using ShoppingCart.SharedKernel.Interfaces;

namespace EmployeeManagement.BusinessLogic.Queries.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IGenericRepository<Employee, int, EmployeeDbContext> _repository;

        public GetEmployeeByIdQueryHandler(IGenericRepository<Employee, int, EmployeeDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id);

            return employee;
        }
    }
}
