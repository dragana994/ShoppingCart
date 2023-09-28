using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.SharedKernel.Persistence.Entities;

namespace ShoppingCart.SharedKernel.Persistence.Configurations
{
    public class StorePartConfiguration : IEntityTypeConfiguration<StorePart>
    {
        public void Configure(EntityTypeBuilder<StorePart> builder)
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

            builder.HasData(
                new StorePart
                {
                    Id = 1,
                    StoreId = 1,
                    PartId = 1,
                    Quantity = 1
                },
                new StorePart
                {
                    Id = 2,
                    StoreId = 1,
                    PartId = 2,
                    Quantity = 2
                },
                new StorePart
                {
                    Id = 3,
                    StoreId = 1,
                    PartId = 3,
                    Quantity = 3
                },
                new StorePart
                {
                    Id = 4,
                    StoreId = 2,
                    PartId = 1,
                    Quantity = 1
                },
                new StorePart
                {
                    Id = 5,
                    StoreId = 2,
                    PartId = 3,
                    Quantity = 6
                },
                new StorePart
                {
                    Id = 6,
                    StoreId = 3,
                    PartId = 1,
                    Quantity = 1
                }
                );
        }
    }
}
