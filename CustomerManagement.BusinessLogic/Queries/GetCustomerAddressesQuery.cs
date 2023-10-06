using CustomerManagement.Core.ValueObjects;
using MediatR;

namespace CustomerManagement.BusinessLogic.Queries
{
    public class GetCustomerAddressesQuery : IRequest<IEnumerable<Address>>
    {
        public int CustomerId { get; set; }
    }
}
