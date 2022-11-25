using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Service
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
