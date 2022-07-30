using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Contexts;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        public PositionRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }
    }
}
