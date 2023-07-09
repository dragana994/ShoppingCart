using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.SharedKernel.Persistence.Entities;

namespace ShoppingCart.SharedKernel.Persistence.Configurations
{
    public class StoreStateConfiguration : IEntityTypeConfiguration<StoreState>
    {
        public void Configure(EntityTypeBuilder<StoreState> builder)
        {
            builder.ToTable("StoreState")
                .HasKey(p => p.Id);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.HasOne(s => s.Store)
                .WithMany(g => g.StoreStates)
                .HasForeignKey(s => s.StoreId);

            builder.HasOne(s => s.Part)
                .WithMany(g => g.StoreStates)
                .HasForeignKey(s => s.PartId);
        }
    }
}
