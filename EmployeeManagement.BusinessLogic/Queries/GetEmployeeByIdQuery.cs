using EmployeeManagement.Core.Entities;
using MediatR;

namespace EmployeeManagement.BusinessLogic.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
