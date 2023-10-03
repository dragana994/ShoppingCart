using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Requests;
using ShoppingCart.BusinessLogic.Commands;
using ShoppingCart.BusinessLogic.Queries;

namespace ShoppingCart.Api.Extensions
{
    public static class ShoppingCartEndpointExtensions
    {
        public static void MapShoppingCartEndpoints(this WebApplication app)
        {
            //Cart
            app.MapPost("/carts", async (IMediator mediator, IMapper mapper, [FromBody] AddCartRequest request) =>
            {
                var command = mapper.Map<AddCartCommand>(request);
                var cart = await mediator.Send(command);

                return Results.Ok(cart);
            });
            app.MapDelete("/carts/{id}", async (IMediator mediator, Guid id) =>
            {
                await mediator.Send(new DeleteCartCommand { Id = id });

                return Results.Ok();
            });
            app.MapPatch("/carts/{id}", async (IMediator mediator, IMapper mapper, [FromBody] ChangeCartStatusRequest request) =>
            {
                var command = mapper.Map<ChangeCartStatusCommand>(request);
                var cart = await mediator.Send(command);

                return Results.Ok(cart);
            });
            app.MapGet("/carts", async (IMediator mediator) =>
            {
                var carts = await mediator.Send(new GetCartsQuery());

                return Results.Ok(carts);
            });
            app.MapGet("/carts/{cartId}", async (IMediator mediator, Guid id) =>
            {
                var cart = await mediator.Send(new GetCartByIdQuery { Id = id });

                return Results.Ok(cart);
            });
            app.MapGet("/customers/{customerId}/carts", async (IMediator mediator, int customerId) =>
            {
                var carts = await mediator.Send(new GetCartsByCustomerIdQuery { CustomerId = customerId });

                return Results.Ok(carts);
            });
            app.MapGet("/employees/{employeeId}/carts", async (IMediator mediator, int employeeId) =>
            {
                var carts = await mediator.Send(new GetCartsByEmployeeIdQuery { EmployeeId = employeeId });

                return Results.Ok(carts);
            });

            //CartItem
            app.MapPost("/carts/cartItems", async (IMediator mediator, IMapper mapper, [FromBody] AddCartItemRequest request) =>
            {
                var command = mapper.Map<AddCartItemCommand>(request);
                var cartItem = await mediator.Send(command);

                return Results.Ok(cartItem);
            });
            app.MapDelete("/carts/{cartId}/cartItems/{cartItemId}", async (IMediator mediator, Guid cartId, Guid cartItemId) =>
            {
                await mediator.Send(new DeleteCartItemCommand { CartId = cartId, CartItemId = cartItemId });

                return Results.Ok();
            });
            app.MapPatch("/carts/{cartId}/cartItems/{cartItemId}", async (IMediator mediator, IMapper mapper, [FromBody] ChangeCartItemQuantityRequest request) =>
            {
                var command = mapper.Map<ChangeCartItemQuantityCommand>(request);
                var cartItem = await mediator.Send(command);

                return Results.Ok(cartItem);
            });
            app.MapGet("/carts/{cartId}/cartItems", async (IMediator mediator, Guid cartId) =>
            {
                var cartItems = await mediator.Send(new GetCartItemsByCartIdQuery { CartId = cartId });

                return Results.Ok(cartItems);
            });
        }
    }
}
