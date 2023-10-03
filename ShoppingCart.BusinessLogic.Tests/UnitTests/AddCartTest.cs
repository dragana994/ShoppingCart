using Moq;
using ShoppingCart.BusinessLogic.Commands;
using ShoppingCart.BusinessLogic.Commands.Handlers;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Infrastracture.Persistence;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.BusinessLogic.Tests.UnitTests
{
    public class AddCartTest : IClassFixture<FixtureTest>
    {
        private readonly AddCartCommandHandler commandHandler;
        private readonly Mock<IGenericRepository<Cart, Guid, ShoppingCartDbContext>> _mockRepository = new();

        public AddCartTest(FixtureTest fixture)
        {
            commandHandler = new AddCartCommandHandler(fixture.Mapper, _mockRepository.Object);
        }

        [Fact]
        public async Task AddCart_ShouldAdded()
        {
            var employeeId = 1;
            var customerId = 2;

            var command = new AddCartCommand
            {
                EmployeeId = employeeId,
                CustomerId = customerId
            };

            _mockRepository.Setup(r => r.AddAsync(It.IsAny<Cart>()))
                .ReturnsAsync(new Cart(employeeId, customerId));

            var result = await commandHandler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddCart_ShouldNotAdded()
        {
            var employeeId = -1;
            var customerId = 2;

            var command = new AddCartCommand
            {
                EmployeeId = employeeId,
                CustomerId = customerId
            };

            await Assert.ThrowsAsync<ArgumentException>(() => commandHandler.Handle(command, CancellationToken.None));
        }
    }
}