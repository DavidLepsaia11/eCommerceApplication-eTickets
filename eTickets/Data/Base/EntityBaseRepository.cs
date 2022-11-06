using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;
        public EntityBaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _dbSet.FindAsync(id);

            if (actor != null)
            {
                //_dbSet.Remove(actor);

                EntityEntry entityEntry = _appDbContext.Entry<T>(actor);
                entityEntry.State = EntityState.Deleted;

                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(int id, T newentity)
        {
            //_dbSet.Update(newentity);
            EntityEntry entityEntry = _appDbContext.Entry<T>(newentity);
            entityEntry.State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id) =>  await _dbSet.AnyAsync(a => a.Id == id);
    
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    }
}
