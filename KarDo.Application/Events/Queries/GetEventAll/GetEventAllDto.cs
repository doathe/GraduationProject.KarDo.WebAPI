using AutoMapper;
using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.AggregateModels.UserEventJoinAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Queries.GetEventAll
{
    public class GetEventAllDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public DateOnly EventDate { get; set; }
        public string Name { get; set; }
        public string ShowType { get; set; }
    }
    public class GetEventAllProfile : Profile
    {
        public GetEventAllProfile()
        {
            CreateMap<GetEventAllQuery, GetEventAllDto>().ReverseMap();
            CreateMap<Event, GetEventAllDto>()
                .ForPath(destination => destination.UserName, operation => operation.MapFrom(source => source.User.UserName))
                .ForMember(destination => destination.ShowType, operation => operation.MapFrom(source => Enum.Parse(typeof(ShowType), source.ShowType.ToString())))
                .ForMember(destination => destination.EventDate, options => options.MapFrom(source => DateOnly.FromDateTime(source.EventDate)));
        }
    }
}
