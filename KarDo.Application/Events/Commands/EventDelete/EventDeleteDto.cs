using AutoMapper;
using KarDo.Domain.AggregateModels.EventAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Commands.EventDelete
{
    public class EventDeleteDto
    {
            public string Message { get; set; }
            public EventDeleteDto()
            {
                Message = "Event deleted successfully";
            }
    }
    public class EventDeleteProfile : Profile
    {
        public EventDeleteProfile()
        {
            CreateMap<EventDeleteCommand, EventDeleteDto>().ReverseMap();
            CreateMap<EventDeleteCommand, Event>().ReverseMap();
            CreateMap<EventDeleteCommand, Event>()
                .ForMember(destination => destination.Id, operation => operation.MapFrom(source => Guid.Parse(source.Id)));
            // Guid.TryParse
        }
    }
}
