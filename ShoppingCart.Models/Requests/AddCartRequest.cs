using ShoppingCart.BusinessLogic.Commands;

namespace ShoppingCart.Models.Requests
{
    public class AddCartRequest : BaseRequest
    { 
        public AddCartCommand Command { get; set; }
    }
}
