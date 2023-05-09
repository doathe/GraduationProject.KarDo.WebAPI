
using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.Interfaces;
using KarDo.Infrastructure.EFCore.Common;
using KarDo.Infrastructure.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Infrastructure.EFCore.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
