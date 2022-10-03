using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IApplicationDbContext appContext) : base(appContext) 
        {
        }

        public override async Task<IEnumerable<Employee>> GetAllAsync() =>
            await appContext.Set<Employee>()
            .AsNoTracking()
            .Include(e => e.Department)
            .Include(e => e.Position)
            .ToListAsync();

        public override async Task<Employee?> GetByIdAsync(int id) =>
            await appContext.Set<Employee>()
            .AsNoTracking()
            .Include(e => e.Department)
            .Include(e => e.Position)
            .SingleOrDefaultAsync(e => e.Id == id);
    }
}
