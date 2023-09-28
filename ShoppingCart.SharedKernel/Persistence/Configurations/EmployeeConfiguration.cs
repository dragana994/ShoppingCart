using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.SharedKernel.Persistence.Entities;
using ShoppingCart.SharedKernel.Persistence.Enums;

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

            builder.Property(x => x.Status)
               .HasConversion<int>()
               .IsRequired();

            builder.HasOne(s => s.Store)
                .WithMany(g => g.Employees)
                .HasForeignKey(s => s.StoreId);

            builder.HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Employee_1",
                    StoreId = 1,
                    Status = EmployeeStatus.Working
                },
                new Employee
                {
                    Id = 2,
                    Name = "Employee_2",
                    StoreId = 1,
                    Status = EmployeeStatus.Working
                },
                new Employee
                {
                    Id = 3,
                    Name = "Employee_3",
                    StoreId = 2,
                    Status = EmployeeStatus.Working
                },
                new Employee
                {
                    Id = 4,
                    Name = "Employee_4",
                    StoreId = 1,
                    Status = EmployeeStatus.Retired
                }
                );
        }
    }
}
