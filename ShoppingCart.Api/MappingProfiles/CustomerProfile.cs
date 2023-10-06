using AutoMapper;
using CustomerManagement.BusinessLogic.Commands;
using ShoppingCart.Api.Requests;

namespace ShoppingCart.Api.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() {

            CreateMap<AddCustomerRequest, AddCustomerCommand>();
            CreateMap<UpdateCustomerAddressesRequest, UpdateCustomerAddressesCommand>();
        }
    }
}
