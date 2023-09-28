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

            builder.HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Customer_1"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Customer_2"
                },
                new Customer
                {
                    Id = 3,
                    Name = "Customer_3"
                },
                new Customer
                {
                    Id = 4,
                    Name = "Customer_4"
                }
            );

            builder.OwnsMany(p => p.Addresses)
            .HasData(new
            {
                Id = 1,
                CustomerId = 1,
                Street = "Street_1",
                City = "City_1",
                Number = "1",
                Country = "Country_1"
            },
            new
            {
                Id = 2,
                CustomerId = 2,
                Street = "Street_2",
                City = "City_2",
                Number = "2",
                Country = "Country_2"
            },
            new
            {
                Id = 3,
                CustomerId = 3,
                Street = "Street_3",
                City = "City_3",
                Number = "3",
                Country = "Country_3"
            });
        }
    }
}
