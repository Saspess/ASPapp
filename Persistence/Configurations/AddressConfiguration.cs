using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.City).HasMaxLength(50).IsRequired();

            builder.Property(a => a.Street).HasMaxLength(50).IsRequired();

            builder.Property(a => a.HouseNumber).IsRequired();

            builder.Property(a => a.HouseCode).HasMaxLength(10);
        }
    }
}
