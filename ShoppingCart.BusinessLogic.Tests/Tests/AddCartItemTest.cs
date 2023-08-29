using NSubstitute;
using ShoppingCart.BusinessLogic.Commands;
using ShoppingCart.BusinessLogic.Commands.Handlers;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Tests.Tests
{
    public class AddCartItemTest : IClassFixture<FixtureTest>
    {
        private readonly AddCartItemCommandHandler commandHandler;
        private readonly IGenericRepository<Cart, Guid> repository;

        public AddCartItemTest(FixtureTest fixture)
        {
            repository = Substitute.For<IGenericRepository<Cart, Guid>>();
            commandHandler = new AddCartItemCommandHandler(fixture.Mapper, repository);
        }

        [Fact]
        public async Task AddCartItem_ShouldAdded()
        {
            var cartId = Guid.NewGuid();

            var command = new AddCartItemCommand
            {
                CartId = cartId,
                PartId = 1,
                Quantity = 1
            };

            repository.GetByIdAsync(cartId).Returns(new Cart
            {
                Id = cartId
            });

            repository.Update(Arg.Any<Cart>()).Returns(new Cart
            {
                Id = cartId
            });

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(1, result.Quantity);
        }
    }
}
