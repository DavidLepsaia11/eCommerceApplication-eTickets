

using eTickets.Domain.Interfaces.Repositories;
using eTickets.Domain.Models;
using eTickets.Infrastracture.Data;

namespace eTickets.Infrastracture.Repositories
{
    public class CinemaRepository : EntityBaseRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
