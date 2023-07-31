using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.Core.CartAggregate;

namespace ShoppingCart.Infrastracture.Persistence.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItem")
                .HasKey(p => p.Id);

            builder.Property(x => x.Quantity)
               .IsRequired();

            builder.OwnsOne(x => x.Price, x =>
            {
                x.Property(pp => pp.Cost).HasColumnName("PriceCost").IsRequired();
                x.Property(pp => pp.Currency).HasColumnName("PriceCurrency").HasMaxLength(5).IsRequired();
            });

            builder.Property(x => x.CartId)
               .IsRequired();

            builder.Property(x => x.PartId)
               .IsRequired();
        }
    }
}
