using NSubstitute;
using ShoppingCart.BusinessLogic.Commands;
using ShoppingCart.BusinessLogic.Commands.Handlers;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Core.Enums;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Tests.Tests
{
    public class ChangeCartStatusTest : IClassFixture<FixtureTest>
    {
        private readonly ChangeCartStatusCommandHandler commandHandler;
        private readonly IGenericRepository<Cart, Guid> repository;

        public ChangeCartStatusTest(FixtureTest fixture)
        {
            repository = Substitute.For<IGenericRepository<Cart, Guid>>();
            commandHandler = new ChangeCartStatusCommandHandler(repository);
        }

        [Fact]
        public async Task ChangeCartStatus_ShouldChanged()
        {
            var cartId = Guid.NewGuid();
            var newCartStatus = CartStatus.Expired;

            var command = new ChangeCartStatusCommand
            {
                Id = cartId,
                Status = newCartStatus,
            };

            repository.GetByIdAsync(cartId).Returns(new Cart
            {
                Id = cartId,
                EmployeeId = 1,
                CustomerId = 1
            });

            repository.Update(Arg.Any<Cart>()).Returns(new Cart
            {
                Id = cartId,
                EmployeeId = 1,
                CustomerId = 1
            });

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(result.Status.Equals(CartStatus.Expired));
        }
    }
}
