using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Extensions;
using ShoppingCart.Api.Middleware;
using ShoppingCart.BusinessLogic.Commands;
using ShoppingCart.Infrastracture.Persistence;
using ShoppingCart.SharedKernel.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddCartCommand).Assembly));
builder.Services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

builder.Services.AddAutoMapper(
    typeof(Program).Assembly,
    typeof(AddCartCommand).Assembly);
builder.Services.AddDbContext<AppDbContext>(options =>
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

//app.MapControllers();
app.MapEndpoints();

app.Run();

public partial class Program { }
