using AutoMapper;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Infrastracture.Persistence;
using MediatR;
using ShoppingCart.SharedKernel.Interfaces;

namespace EmployeeManagement.BusinessLogic.Commands.Handlers
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Employee, int, EmployeeDbContext> _repository;

        public AddEmployeeCommandHandler(IMapper mapper, IGenericRepository<Employee, int, EmployeeDbContext> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Employee> Handle(AddEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employeeToAdd = _mapper.Map<Employee>(command);
            await _repository.AddAsync(employeeToAdd);

            return employeeToAdd;
        }
    }
}
