
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

    }
}
