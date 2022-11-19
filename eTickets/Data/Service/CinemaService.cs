using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Service
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
    {
        public CinemaService(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
