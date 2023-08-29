using AutoMapper;
using ShoppingCart.BusinessLogic.Commands;

namespace ShoppingCart.BusinessLogic.Tests
{
    public class FixtureTest
    {
        public IMapper Mapper { get; } = GetMapper();

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(new[] 
            {
                typeof(AddCartCommand).Assembly
            }));

            return config.CreateMapper();
        }
    }
}
