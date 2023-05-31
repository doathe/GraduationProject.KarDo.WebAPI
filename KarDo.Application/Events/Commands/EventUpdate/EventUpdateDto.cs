using AutoMapper;
using KarDo.Domain.AggregateModels.EventAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Commands.EventUpdate
{
    public class EventUpdateDto
    {
        public string Message { get; set; }
        public EventUpdateDto()
        {
            Message = "Event updated successfully";
        }
    }
    public class EventCreateProfile : Profile
    {
        public EventCreateProfile()
        {
            CreateMap<EventUpdateCommand, EventUpdateDto>().ReverseMap();
            CreateMap<EventUpdateCommand, Event>().ReverseMap();
            CreateMap<EventUpdateCommand, Event>()
                .ForMember(destination => destination.ShowType, operation => operation.MapFrom(source => (int)Enum.Parse(typeof(ShowType), source.ShowType)));
            //  .ForMember(destination => destination.ShowType, operation => operation.MapFrom(source => ((ShowType)source.ShowType).ToString()));
        }
    }
}
