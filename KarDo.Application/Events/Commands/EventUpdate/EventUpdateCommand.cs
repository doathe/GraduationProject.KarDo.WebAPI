using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Commands.EventUpdate
{
    public class EventUpdateCommand : IRequest<EventUpdateDto>
    {
        public string EventId { get; set; }
        public DateTime EventDate { get; set; }
        public string Name { get; set; }
        public string ShowType { get; set; }

    }
}
