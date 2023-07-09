using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.SharedKernel.Persistence.Entities;

namespace ShoppingCart.SharedKernel.Persistence.Configurations
{
    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.ToTable("Part").HasKey(p => p.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.OwnsOne(x => x.Price, x =>
            {
                x.Property(pp => pp.Cost).HasColumnName("PriceCost").IsRequired();
                x.Property(pp => pp.Currency).HasColumnName("PriceCurrency").HasMaxLength(5).IsRequired();
            });

            builder.OwnsOne(x => x.Manufacturer, x =>
            {
                x.Property(pp => pp.Name).HasColumnName("ManufacturerName").HasMaxLength(50);
            });
        }
    }
}
