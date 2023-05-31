using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Commands.EventDelete
{
    public class EventDeleteCommand : IRequest<EventDeleteDto>
    {
        public string Id { get; set; }
    }
}
