using ShoppingCart.SharedKernel;

namespace ShoppingCart.Api.Requests
{
    public class AddEmployeeRequest : BaseRequest
    {
        public string Name { get; set; }
        public int StoreId { get; set; }
    }
}
