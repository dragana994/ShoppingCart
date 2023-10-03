using EmployeeManagement.BusinessLogic.Commands;
using EmployeeManagement.Infrastracture.Persistence;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Extensions;
using ShoppingCart.Api.Middleware;
using ShoppingCart.BusinessLogic.Commands;
using ShoppingCart.Infrastracture.Persistence;
using ShoppingCart.SharedKernel;
using ShoppingCart.SharedKernel.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddCartCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddEmployeeCommand).Assembly));

builder.Services.AddTransient(typeof(IGenericRepository<,,>), typeof(GenericRepository<,,>));

builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddAutoMapper(
    typeof(Program).Assembly,
    typeof(AddCartCommand).Assembly,
    typeof(AddEmployeeCommand).Assembly);

builder.Services.AddDbContext<ShoppingCartDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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

app.Run();

public partial class Program { }
