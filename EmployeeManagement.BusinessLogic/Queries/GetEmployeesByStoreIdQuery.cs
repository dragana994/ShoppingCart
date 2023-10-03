using EmployeeManagement.Core.Entities;
using MediatR;

namespace EmployeeManagement.BusinessLogic.Queries
{
    public class GetEmployeesByStoreIdQuery : IRequest<IEnumerable<Employee>>
    {
        public int StoreId { get; set; }
    }
}
