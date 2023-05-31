using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.AggregateModels.UserAggregate;
using KarDo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Domain.AggregateModels.UserEventJoinAggregate
{
    public class UserEventJoin: BaseEntity
    {
        public bool IsJoined { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
