using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.SharedKernel.Persistence.Entities;

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

            builder.OwnsOne(x => x.Residence, x =>
            {
                x.Property(pp => pp.Country).HasColumnName("ResidenceCountry").HasMaxLength(50).IsRequired();
                x.Property(pp => pp.City).HasColumnName("ResidenceCity").HasMaxLength(50).IsRequired();
                x.Property(pp => pp.Street).HasColumnName("ResidenceStreet").HasMaxLength(50).IsRequired();
                x.Property(pp => pp.Number).HasColumnName("ResidenceNumber").HasMaxLength(5).IsRequired();
            });
        }
    }
}
