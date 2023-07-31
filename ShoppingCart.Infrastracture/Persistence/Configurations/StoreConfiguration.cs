using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.Core.Entities;

namespace ShoppingCart.Infrastracture.Persistence.Configurations
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
                x.Property(pp => pp.Country).HasColumnName("Address_Country").HasMaxLength(50).IsRequired();
                x.Property(pp => pp.City).HasColumnName("Address_City").HasMaxLength(50).IsRequired();
                x.Property(pp => pp.Street).HasColumnName("Address_Street").HasMaxLength(50).IsRequired();
                x.Property(pp => pp.Number).HasColumnName("Address_Number").HasMaxLength(5).IsRequired();
            });
        }
    }
}
