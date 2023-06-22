using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Requests;
using ShoppingCart.BusinessLogic.Commands;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.Api.Extensions
{
    public static class EndpointExtensions
    {
        public static void MapEndpoints(this WebApplication app)
        {
            /*app.MapGet("/cart", async (IMediator mediator, [AsParameters] GetCartsQuery query) =>
            {
                var carts = await mediator.Send(query);
                return Results.Ok(carts);
            });*/

            app.MapPost("/cart", async (IMediator mediator, IMapper mapper,[FromBody] AddCartRequest request) =>
            {
                var command = mapper.Map<AddCartCommand>(request);
                var cart = await mediator.Send(command);
                return Results.Ok(cart);
            });
        }


    }
}
