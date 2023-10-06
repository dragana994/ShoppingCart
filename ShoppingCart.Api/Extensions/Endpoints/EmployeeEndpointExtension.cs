using AutoMapper;
using EmployeeManagement.BusinessLogic.Commands;
using EmployeeManagement.BusinessLogic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Requests;

namespace ShoppingCart.Api.Extensions.Endpoints
{
    public static class EmployeeEndpointExtension
    {
        public static void MapEmployeeEndpoints(this WebApplication app)
        {
            app.MapPost("/employee", async (IMediator mediator, IMapper mapper, [FromBody] AddEmployeeRequest request) =>
            {
                var command = mapper.Map<AddEmployeeCommand>(request);
                var employee = await mediator.Send(command);

                return Results.Ok(employee);
            });
            app.MapPatch("/employee/{id}", async (IMediator mediator, IMapper mapper, [FromBody] ChangeEmployeeStatusRequest request) =>
            {
                var command = mapper.Map<ChangeEmployeeStatusCommand>(request);
                var employee = await mediator.Send(command);

                return Results.Ok(employee);
            });
            app.MapGet("/employees", async (IMediator mediator) =>
            {
                var employees = await mediator.Send(new GetEmployeesQuery());

                return Results.Ok(employees);
            });
            app.MapGet("/employees/{employeeId}", async (IMediator mediator, int id) =>
            {
                var employee = await mediator.Send(new GetEmployeeByIdQuery { Id = id });

                return Results.Ok(employee);
            });
            app.MapGet("/store/{storeId}/employees", async (IMediator mediator, int storeId) =>
            {
                var employees = await mediator.Send(new GetEmployeesByStoreIdQuery { StoreId = storeId });

                return Results.Ok(employees);
            });
        }
    }
}
