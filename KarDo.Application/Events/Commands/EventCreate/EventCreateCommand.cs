using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Commands.EventCreate
{
    public class EventCreateCommand : IRequest<EventCreateDto>
    {
        public DateTime EventDate { get; set; }
        public string Name { get; set; }
        public string ShowType { get; set; }
        [FromBody] // UserId özelliği istekte alınmaz
        public string? UserId { get; set; }
    }
}
