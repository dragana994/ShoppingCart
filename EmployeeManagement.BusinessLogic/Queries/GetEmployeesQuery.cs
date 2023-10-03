using EmployeeManagement.Core.Entities;
using MediatR;

namespace EmployeeManagement.BusinessLogic.Queries
{
    public class GetEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
    }
}
