using AutoMapper;
using ShoppingCart.Api.Requests;
using ShoppingCart.BusinessLogic.Commands;

namespace ShoppingCart.Api.MappingProfiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<AddCartItemRequest, AddCartItemCommand>();
            CreateMap<ChangeCartItemQuantityRequest, ChangeCartItemQuantityCommand>();
        }
    }
}
