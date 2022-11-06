using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Service
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _dbContext;

        public ActorsService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Actor actor)
        {
           await _dbContext.Actors.AddAsync(actor);
           await  _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _dbContext.Actors.FindAsync(id);

            if (actor !=null)
            {
                _dbContext.Actors.Remove(actor);
                await _dbContext.SaveChangesAsync();
            }
        }

        public Task<bool> Exists(int id)
        {
            return _dbContext.Actors.AnyAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _dbContext.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor?> GetByIdAsync(int id)
        {
           return await _dbContext.Actors.FindAsync(id);
        }

        public async Task<Actor> UpdateAsync(int id, Actor actor)
        {
            _dbContext.Update(actor);
             _dbContext.SaveChanges();
            return actor;
        }
    }
}
