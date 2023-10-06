using MediatR;

namespace CustomerManagement.BusinessLogic.Commands
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
