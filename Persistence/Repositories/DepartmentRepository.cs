using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<Department>> GetAllAsync() =>
            await appContext.Set<Department>()
            .AsNoTracking()
            .Include(d => d.Organization)
            .ToListAsync();

        public override async Task<Department?> GetByIdAsync(int id) =>
            await appContext.Set<Department>()
            .AsNoTracking()
            .Include(d => d.Organization)
            .SingleOrDefaultAsync(e => e.Id == id);
    }
}
