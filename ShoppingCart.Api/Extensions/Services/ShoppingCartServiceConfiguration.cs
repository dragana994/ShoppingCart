using Microsoft.EntityFrameworkCore;
using ShoppingCart.BusinessLogic.Commands;
using ShoppingCart.Infrastracture.Persistence;

namespace ShoppingCart.Api.Extensions.Services
{
    public static class ShoppingCartServiceConfiguration
    {
        public static void AddShoppingCartConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(AddCartCommand).Assembly);

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddCartCommand).Assembly));

            builder.Services.AddDbContext<ShoppingCartDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
