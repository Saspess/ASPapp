﻿using Domain.Entities;
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

            builder.Property(e => e.AddressId).IsRequired();
            builder.Property(e => e.DepartmentId).IsRequired();
            builder.Property(e => e.PositionId).IsRequired();
            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.PhoneNumber).HasMaxLength(50).IsRequired();
            builder.HasIndex(e => e.PhoneNumber).IsUnique();
            builder.Property(e => e.Birthday).IsRequired();
            builder.HasCheckConstraint("Birthday", "(YEAR(Birthday) < (YEAR(CURDATE()) - 18) AND YEAR(Birthday) > (YEAR(CURDATE()) - 100)");
        }
    }
}
