using eTickets.Domain.Interfaces.Repositories;
using eTickets.Domain.Models;
using eTickets.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Infrastracture.Repositories
{
    public class ProducerRepository : EntityBaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
