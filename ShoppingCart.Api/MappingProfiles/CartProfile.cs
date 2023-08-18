using AutoMapper;
using ShoppingCart.Api.Requests;
using ShoppingCart.BusinessLogic.Commands;

namespace ShoppingCart.Api.MappingProfiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<AddCartRequest, AddCartCommand>();
            CreateMap<ChangeCartStatusRequest, ChangeCartStatusCommand>();
        }
    }
}
