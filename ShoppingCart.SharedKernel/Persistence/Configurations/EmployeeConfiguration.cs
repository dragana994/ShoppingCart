using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.SharedKernel.Persistence.Entities;

namespace ShoppingCart.SharedKernel.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee")
                .HasKey(x => x.Id);

            builder.Property(x => x.Name)
            .IsRequired()
               .HasMaxLength(50);

            builder.HasOne(s => s.Store)
                .WithMany(g => g.Employees)
                .HasForeignKey(s => s.StoreId);
        }
    }
}
