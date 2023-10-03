using EmployeeManagement.Core.Enums;
using ShoppingCart.SharedKernel;

namespace ShoppingCart.Api.Requests
{
    public class ChangeEmployeeStatusRequest : BaseRequest
    {
        public int Id { get; set; }
        public EmployeeStatus Status { get; set; }
    }
}
