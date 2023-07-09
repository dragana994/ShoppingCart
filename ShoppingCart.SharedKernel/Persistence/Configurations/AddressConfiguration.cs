using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.SharedKernel.Persistence.Entities;

namespace ShoppingCart.SharedKernel.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address")
                .HasKey(p => p.Id);

            builder.Property(x => x.IsPrimary)
                .IsRequired();

            builder.Property(x => x.Country)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.City)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Street)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Country)
                .HasMaxLength(5)
                .IsRequired();

            builder.HasOne(s => s.Customer)
                .WithMany(g => g.Addresses)
                .HasForeignKey(s => s.CustomerId);
        }
    }
}
