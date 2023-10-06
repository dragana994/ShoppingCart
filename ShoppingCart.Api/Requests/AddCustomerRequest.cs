using ShoppingCart.SharedKernel;

namespace ShoppingCart.Api.Requests
{
    public class AddCustomerRequest : BaseRequest
    {
        public string Name { get; set; }
    }
}
