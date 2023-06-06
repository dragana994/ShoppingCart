using MediatR;
using ShoppingCart.Api.Commands;
using ShoppingCart.Api.Queries;

namespace ShoppingCart.Api.Extensions
{
    public static class EndpointExtensions
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapGet("/cart", async (IMediator mediator, [AsParameters] GetCartsQuery query) =>
            {
                var carts = await mediator.Send(query);
                return Results.Ok(carts);
            });

            app.MapPost("/cart", async (IMediator mediator, [AsParameters] AddCartCommand command) =>
            {
                var guid = await mediator.Send(command);
                return Results.Ok(guid);
            });
        }


    }
}
