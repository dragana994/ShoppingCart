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
                x.Property(pp => pp.Cost)
                .HasPrecision(10, 3)
                .IsRequired();

                x.Property(pp => pp.Currency).
                HasMaxLength(5)
                .IsRequired();

                x.HasData(
                    new
                    {
                        PartId = 1,
                        Cost = 10,
                        Currency = "BAM"
                    },
                     new
                     {
                         PartId = 2,
                         Cost = 20,
                         Currency = "BAM"
                     },
                     new
                     {
                         PartId = 3,
                         Cost = 30,
                         Currency = "BAM"
                     });
            });

            builder.OwnsOne(x => x.Manufacturer, x =>
            {
                x.Property(pp => pp.Name)
                .HasMaxLength(50);

                x.HasData(
                    new
                    {
                        PartId = 1,
                        Name = "Manufacturer_1"
                    },
                     new
                     {
                         PartId = 2,
                         Name = "Manufacturer_2"
                     },
                     new
                     {
                         PartId = 3,
                         Name = "Manufacturer_3"
                     });
            });

            builder.HasData(
                new Part
                {
                    Id = 1,
                    Name = "Part_1"
                },
                 new Part
                 {
                     Id = 2,
                     Name = "Part_2"
                 },
                  new Part
                  {
                      Id = 3,
                      Name = "Part_3"
                  }
                );
        }
    }
}
