using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.PhoneNumber).HasMaxLength(50).IsRequired();
            builder.HasIndex(e => e.PhoneNumber).IsUnique();
            builder.HasCheckConstraint("Birthday", "YEAR(Birthday) < 2022 AND YEAR(Birthday) > 1922");
        }
    }
}
