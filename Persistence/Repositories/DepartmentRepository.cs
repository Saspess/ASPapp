using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Contexts;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }
    }
}
