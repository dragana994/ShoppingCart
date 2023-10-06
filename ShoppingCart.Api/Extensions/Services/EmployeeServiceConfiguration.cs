using EmployeeManagement.BusinessLogic.Commands;
using EmployeeManagement.Infrastracture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Api.Extensions.Services
{
    public static class EmployeeServiceConfiguration
    {
        public static void AddEmployeeConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(AddEmployeeCommand).Assembly);

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddEmployeeCommand).Assembly));

            builder.Services.AddDbContext<EmployeeDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
