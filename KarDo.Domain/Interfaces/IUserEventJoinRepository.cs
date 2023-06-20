using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.AggregateModels.UserEventJoinAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Domain.Interfaces
{
    public interface IUserEventJoinRepository
    {
        public Task<IEnumerable<string>> UserEventJoinCheckAsync(UserEventJoin entity);
        public Task UserEventJoinAddAsync(UserEventJoin entity);
        public Task UserEventJoinUpdateAsync(UserEventJoin entity);
        public Task UserEventJoinDeleteAsync(UserEventJoin entity);
    }
}
