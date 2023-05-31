using KarDo.Domain.AggregateModels.UserAggregate;
using KarDo.Domain.AggregateModels.UserEventJoinAggregate;
using KarDo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Domain.AggregateModels.EventAggregate
{
    public class Event : BaseEntity
    {
        public DateTime EventDate { get; set; }
        public string Name { get; set; }
        public int ShowType { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<UserEventJoin> EventUserJoins { get; set; }
    }

    public enum ShowType
    {
        Public = 1,
        Private = 2,
    }
}
