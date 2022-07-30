using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Contexts;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class OrganizationRepository : GenericRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }
    }
}
