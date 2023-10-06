using CustomerManagement.Core.ValueObjects;
using ShoppingCart.SharedKernel;

namespace ShoppingCart.Api.Requests
{
    public class UpdateCustomerAddressesRequest : BaseRequest
    {
        public int CustomerId { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
