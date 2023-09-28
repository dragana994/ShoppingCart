using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.SharedKernel.Persistence.Entities;

namespace ShoppingCart.SharedKernel.Persistence.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart").HasKey(p => p.Id);

            builder.Property(x => x.CreatedDate)
             .IsRequired();

            builder.Property(x => x.Status)
               .HasConversion<int>()
               .IsRequired();

            builder.HasOne(s => s.Employee)
                .WithMany(g => g.Carts)
                .HasForeignKey(s => s.EmployeeId);

            builder.HasOne(s => s.Customer)
                .WithMany(g => g.Carts)
                .HasForeignKey(s => s.CustomerId);
        }
    }
}