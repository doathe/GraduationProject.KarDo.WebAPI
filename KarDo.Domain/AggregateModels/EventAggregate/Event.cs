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
    }

    public enum ShowType
    {
        Eveyone = 1,
        OnlyMe = 2,
    }
}
