using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingCart.Core.CartAggregate;
using ShoppingCart.Core.Entities;
using ShoppingCart.SharedKernel;
using System.Reflection;

namespace ShoppingCart.Infrastracture.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected readonly IConfiguration Configuration;
        private readonly IMediator _mediator;

        public AppDbContext(IConfiguration configuration, IMediator mediator)
        {
            Configuration = configuration;
            _mediator = mediator;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (_mediator == null) return result;

            var entitiesWithEvents = ChangeTracker
                .Entries()
                .Select(e => e.Entity as BaseEntity<Guid>)
                .Where(e => e?.Events != null && e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent, cancellationToken).ConfigureAwait(false);
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
