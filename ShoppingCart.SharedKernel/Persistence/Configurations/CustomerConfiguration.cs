using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.SharedKernel.Persistence.Entities;

namespace ShoppingCart.SharedKernel.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer")
                .HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.OwnsMany(p => p.Addresses, a =>
            {
                a.WithOwner().HasForeignKey("CustomerId");
                a.Property<int>("Id");
                a.HasKey("Id");
            });
        }
    }
}
