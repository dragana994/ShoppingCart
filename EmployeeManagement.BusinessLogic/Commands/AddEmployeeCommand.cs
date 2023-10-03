using EmployeeManagement.Core.Entities;
using MediatR;

namespace EmployeeManagement.BusinessLogic.Commands
{
    public class AddEmployeeCommand : IRequest<Employee>
    {
        public string Name { get; set; }
        public int StoreId { get; set; }
    }
}
