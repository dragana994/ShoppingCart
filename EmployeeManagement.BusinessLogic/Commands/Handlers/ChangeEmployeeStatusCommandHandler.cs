using EmployeeManagement.Core.Entities;
using EmployeeManagement.Infrastracture.Persistence;
using MediatR;
using ShoppingCart.SharedKernel.Exceptions;
using ShoppingCart.SharedKernel.Interfaces;

namespace EmployeeManagement.BusinessLogic.Commands.Handlers
{
    public class ChangeEmployeeStatusCommandHandler : IRequestHandler<ChangeEmployeeStatusCommand, Employee>
    {
        private readonly IGenericRepository<Employee, int, EmployeeDbContext> _repository;

        public ChangeEmployeeStatusCommandHandler(IGenericRepository<Employee, int, EmployeeDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<Employee> Handle(ChangeEmployeeStatusCommand command, CancellationToken cancellationToken)
        {
            var employeeToUpdate = await _repository.GetByIdAsync(command.Id);

            if (employeeToUpdate is null)
            {
                throw new DomainException($"Changing status not sucessful! Not found a employee with id {command.Id}");
            }

            employeeToUpdate.ChangeStatus(command.Status);

            _repository.Update(employeeToUpdate);

            return employeeToUpdate;
        }
    }
}
