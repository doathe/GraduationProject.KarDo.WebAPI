
using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Domain.Interfaces
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        public Task UpdateEventAsync(Event entity, string id);
        public Task<IEnumerable<Event>> GetEventAllAsync();
        public Task<IEnumerable<Event>> GetEventByUserIdAsync(string id);
    }
}
