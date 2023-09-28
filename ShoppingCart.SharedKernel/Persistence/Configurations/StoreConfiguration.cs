using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.SharedKernel.Persistence.Entities;
using ShoppingCart.SharedKernel.Persistence.ValueObjects;

namespace ShoppingCart.SharedKernel.Persistence.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Store")
                .HasKey(p => p.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.OwnsOne(x => x.Address, x =>
            {
                x.Property(pp => pp.Country).HasMaxLength(50).IsRequired();
                x.Property(pp => pp.City).HasMaxLength(50).IsRequired();
                x.Property(pp => pp.Street).HasMaxLength(50).IsRequired();
                x.Property(pp => pp.Number).HasMaxLength(5).IsRequired();

                x.HasData(
                    new
                    {
                        StoreId = 1,
                        Country = "Country_1",
                        City = "City_1",
                        Number = "1",
                        Street = "Street_1"
                    },
                    new
                    {
                        StoreId = 2,
                        Country = "Country_2",
                        City = "City_2",
                        Number = "2",
                        Street = "Street_2"
                    },
                    new
                    {
                        StoreId = 3,
                        Country = "Country_3",
                        City = "City_3",
                        Number = "3",
                        Street = "Street_3"
                    }
                    );
            });

            builder.HasData(
                new Store
                {
                    Id = 1,
                    Name = "Store_1"
                },
                new Store
                {
                    Id = 2,
                    Name = "Store_2"
                },
                new Store
                {
                    Id = 3,
                    Name = "Store_3"
                }
                );
        }
    }
}
