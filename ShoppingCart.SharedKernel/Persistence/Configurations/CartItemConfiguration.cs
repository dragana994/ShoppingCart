using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.SharedKernel.Persistence.Entities;

namespace ShoppingCart.SharedKernel.Persistence.Configurations
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

            builder.HasOne(s => s.Cart)
                .WithMany(g => g.CartItems)
                .HasForeignKey(s => s.CartId);

            builder.HasOne(s => s.Part)
                .WithMany(g => g.CartItems)
                .HasForeignKey(s => s.PartId);
        }
    }
}
