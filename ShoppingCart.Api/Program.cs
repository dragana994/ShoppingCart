using ShoppingCart.Api.Extensions.Endpoints;
using ShoppingCart.Api.Extensions.Services;
using ShoppingCart.Api.Middleware;
using ShoppingCart.SharedKernel;
using ShoppingCart.SharedKernel.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.AddCustomerConfiguration();
builder.AddEmployeeConfiguration();
builder.AddShoppingCartConfiguration();

builder.Services.AddTransient(typeof(IGenericRepository<,,>), typeof(GenericRepository<,,>));

builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.MapShoppingCartEndpoints();
app.MapEmployeeEndpoints();
app.MapCustomerEndpoints();

app.Run();

public partial class Program { }
