using eTickets.Domain.Interfaces.Repositories;
using eTickets.Domain.Models;
using eTickets.Infrastracture.Data;

namespace eTickets.Infrastracture.Repositories
{
    public class ActorRepository : EntityBaseRepository<Actor>, IActorRepository
    {
        public ActorRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
