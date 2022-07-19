using Domain.Entities;
using Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Organization> Organizations { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        }
    }
}
