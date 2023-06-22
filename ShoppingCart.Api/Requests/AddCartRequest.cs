using ShoppingCart.SharedKernel;

namespace ShoppingCart.Api.Requests
{
    public class AddCartRequest : BaseRequest
    { 
        public int UserId { get; set; }
    }
}
