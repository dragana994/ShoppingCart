using ShoppingCart.SharedKernel;

namespace ShoppingCart.Api.Requests
{
    public class AddCartItemRequest : BaseRequest
    {
        public Guid CartId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
    }
}
