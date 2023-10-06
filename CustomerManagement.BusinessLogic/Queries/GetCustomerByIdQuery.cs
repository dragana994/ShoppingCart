using CustomerManagement.Core.Entities;
using MediatR;

namespace CustomerManagement.BusinessLogic.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; set; }
    }
}
