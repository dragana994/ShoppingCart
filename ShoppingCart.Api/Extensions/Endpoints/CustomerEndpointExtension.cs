using AutoMapper;
using CustomerManagement.BusinessLogic.Commands;
using CustomerManagement.BusinessLogic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Requests;

namespace ShoppingCart.Api.Extensions.Endpoints
{
    public static class CustomerEndpointExtension
    {
        public static void MapCustomerEndpoints(this WebApplication app)
        {
            app.MapPost("/customer", async (IMediator mediator, IMapper mapper, [FromBody] AddCustomerRequest request) =>
            {
                var command = mapper.Map<AddCustomerCommand>(request);
                var customer = await mediator.Send(command);

                return Results.Ok(customer);
            });
            app.MapPost("/customer/{id}/addresses", async (IMediator mediator, IMapper mapper, [FromBody] UpdateCustomerAddressesRequest request) =>
            {
                var command = mapper.Map<UpdateCustomerAddressesCommand>(request);
                var customer = await mediator.Send(command);

                return Results.Ok(customer);
            });
            app.MapGet("/customers", async (IMediator mediator) =>
            {
                var customers = await mediator.Send(new GetCustomersQuery());

                return Results.Ok(customers);
            });
            app.MapGet("/customer/{customerId}", async (IMediator mediator, int id) =>
            {
                var customer = await mediator.Send(new GetCustomerByIdQuery { Id = id });

                return Results.Ok(customer);
            });
            app.MapGet("/customer/{customerId}/addresses", async (IMediator mediator, int customerId) =>
            {
                var addresses = await mediator.Send(new GetCustomerAddressesQuery { CustomerId = customerId });

                return Results.Ok(addresses);
            });
        }
    }
}
