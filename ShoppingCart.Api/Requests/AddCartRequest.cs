using ShoppingCart.SharedKernel;

namespace ShoppingCart.Api.Requests
{
    public class AddCartRequest : BaseRequest
    {
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
    }
}
