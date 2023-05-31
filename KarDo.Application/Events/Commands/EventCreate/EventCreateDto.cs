using AutoMapper;
using KarDo.Domain.AggregateModels.EventAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Commands.EventCreate
{
    public class EventCreateDto
    {
        public string Message { get; set; }
        public EventCreateDto()
        {
            Message = "Event created successfully";
        }
    }
    public class EventCreateProfile : Profile
    {
        public EventCreateProfile()
        {
            CreateMap<EventCreateCommand, EventCreateDto>().ReverseMap();
            CreateMap<EventCreateCommand, Event>().ReverseMap();
            CreateMap<EventCreateCommand, Event>()
                .ForMember(destination => destination.ShowType, operation => operation.MapFrom(source => (int)Enum.Parse(typeof(ShowType), source.ShowType)));
            //  .ForMember(destination => destination.ShowType, operation => operation.MapFrom(source => ((ShowType)source.ShowType).ToString()));
        }
    }
}
