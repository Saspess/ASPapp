using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Contexts;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IApplicationDbContext appContext) : base(appContext) 
        {
        }
    }
}
