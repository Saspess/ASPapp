using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Contexts;
using Application.Common.Exceptions;
using Domain.Common;

namespace Persistence.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected IApplicationDbContext AppContext;

        public GenericRepository(IApplicationDbContext appContext)
        {
            AppContext = appContext;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() =>
           await AppContext.Set<TEntity>()
           .AsNoTracking()
           .ToListAsync();

        public virtual async Task<TEntity?> GetByIdAsync(int id) =>
            await AppContext.Set<TEntity>()
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.Id == id);

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var created = await AppContext.Set<TEntity>().AddAsync(entity);
            await AppContext.SaveChangesAsync();

            return created.Entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            AppContext.Set<TEntity>().Update(entity);
            await AppContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await AppContext.Set<TEntity>().FindAsync(id);
            
            AppContext.Set<TEntity>().Remove(entity);
            await AppContext.SaveChangesAsync();
        }
    }
}
