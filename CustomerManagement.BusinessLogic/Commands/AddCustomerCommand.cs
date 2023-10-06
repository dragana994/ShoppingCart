using CustomerManagement.Core.Entities;
using CustomerManagement.Core.ValueObjects;
using MediatR;

namespace CustomerManagement.BusinessLogic.Commands
{
    public class AddCustomerCommand : IRequest<Customer>
    {
        public string Name { get; set; }
    }
}
