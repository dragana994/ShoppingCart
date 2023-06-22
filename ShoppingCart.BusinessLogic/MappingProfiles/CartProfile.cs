using AutoMapper;
using ShoppingCart.BusinessLogic.Commands;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.BusinessLogic.MappingProfiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<AddCartCommand, Cart>();
        }
    }
}
