using CustomerManagement.BusinessLogic.Commands;
using CustomerManagement.Infrastracture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Api.Extensions.Services
{
    public static class CustomerServiceConfiguration
    {
        public static void AddCustomerConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(AddCustomerCommand).Assembly);

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddCustomerCommand).Assembly));

            builder.Services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
