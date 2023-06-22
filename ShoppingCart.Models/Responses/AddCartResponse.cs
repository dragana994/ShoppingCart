using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.Models.Responses
{
    public class AddCartResponse : BaseResponse
    {
        //ovaj Cart ne bi trebao biti agregat nego neki dto objekat koji vracam?
        public Cart Cart { get; set; }
    }
}
