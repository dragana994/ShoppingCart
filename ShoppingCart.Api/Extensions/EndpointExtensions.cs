using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Api.Extensions
{
    public static class EndpointExtensions
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapGet("/user", async ([FromBody] int test ,IMediator mediator) =>
            {
                //var user = await mediator.Send(""));
                //return Results.Ok(user);
            });
        }

        
    }
}
