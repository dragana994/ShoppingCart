using AutoMapper;
using ShoppingCart.BusinessLogic.Commands;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.BusinessLogic.MappingProfiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile() {
            CreateMap<AddCartItemCommand, CartItem>();
        }
    }
}
