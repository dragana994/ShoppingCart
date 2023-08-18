using ShoppingCart.Core.Enums;

namespace ShoppingCart.Api.Requests
{
    public class ChangeCartStatusRequest
    {
        public Guid Id { get; set; }
        public CartStatus Status { get; set; }
    }
}
