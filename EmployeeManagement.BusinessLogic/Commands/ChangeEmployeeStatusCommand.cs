using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Enums;
using MediatR;

namespace EmployeeManagement.BusinessLogic.Commands
{
    public class ChangeEmployeeStatusCommand : IRequest<Employee>
    {
        public int Id { get; set; }
        public EmployeeStatus Status { get; set; }
    }
}
