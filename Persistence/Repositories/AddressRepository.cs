using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Contexts;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }
    }
}
