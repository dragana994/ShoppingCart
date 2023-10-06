using CustomerManagement.Core.Entities;
using MediatR;

namespace CustomerManagement.BusinessLogic.Queries
{
    public class GetCustomersQuery : IRequest<IEnumerable<Customer>>
    {
    }
}
