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

        public void Add(Actor actor)
        {
            _dbContext.Actors.AddAsync(actor);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await _dbContext.Actors.ToListAsync();
            return result;
        }

        public Actor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Actor Update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}
