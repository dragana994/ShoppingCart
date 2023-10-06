using ShoppingCart.Core.Enums;
using ShoppingCart.SharedKernel;

namespace ShoppingCart.Api.Requests
{
    public class ChangeCartStatusRequest : BaseRequest
    {
        public Guid Id { get; set; }
        public CartStatus Status { get; set; }
    }
}
