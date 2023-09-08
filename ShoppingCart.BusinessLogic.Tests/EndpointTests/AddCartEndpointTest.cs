using ShoppingCart.Api.Requests;
using ShoppingCart.Core.CartAggregate;
using System.Net;
using System.Net.Http.Json;

namespace ShoppingCart.BusinessLogic.Tests.EndpointTests
{
    public class AddCartEndpointTest : IClassFixture<EndpointWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AddCartEndpointTest(EndpointWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task AddCart_ShouldReturn200()
        {
            var request = new AddCartRequest
            {
                EmployeeId = 1,
                CustomerId = 2
            };

            var result = await _client.PostAsJsonAsync("/carts", request);
            var content = await result.Content.ReadFromJsonAsync<Cart>();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(content);
        }

        [Fact]
        public async Task AddCart_ShouldReturnBadRequest()
        {
            var request = new AddCartRequest
            {
                EmployeeId = -1,
                CustomerId = -2
            };

            var result = await _client.PostAsJsonAsync("/carts", request);

            Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);

        }
    }
}
