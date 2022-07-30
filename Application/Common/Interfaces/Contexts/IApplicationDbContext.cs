using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Common.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Organization> Organizations { get; set; }
        DbSet<Position> Positions { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
