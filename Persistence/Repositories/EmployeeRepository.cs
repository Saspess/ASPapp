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

        public async Task<Employee?> GetByLastName(string lastName) =>
            await AppContext.Set<Employee>()
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.LastName == lastName);
    }
}
