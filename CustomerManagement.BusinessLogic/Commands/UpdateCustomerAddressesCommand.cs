using CustomerManagement.Core.Entities;
using CustomerManagement.Core.ValueObjects;
using MediatR;

namespace CustomerManagement.BusinessLogic.Commands
{
    public class UpdateCustomerAddressesCommand : IRequest<Customer>
    {
        public int CustomerId { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
