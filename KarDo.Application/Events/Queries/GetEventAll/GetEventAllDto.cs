using AutoMapper;
using KarDo.Application.Events.Commands.EventDelete;
using KarDo.Domain.AggregateModels.EventAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Queries.GetEventAll
{
    public class GetEventAllDto
    {
        public string UserName { get; set; }
        public DateTime EventDate { get; set; }
        public string Name { get; set; }
        public string ShowType { get; set; }
    }
    public class GetEventAllProfile : Profile
    {
        public GetEventAllProfile()
        {
            CreateMap<GetEventAllQuery, GetEventAllDto>().ReverseMap();
            CreateMap<GetEventAllDto, Event>().ReverseMap()
                .ForPath(destination => destination.UserName, operation => operation.MapFrom(source => source.User.UserName))
                .ForMember(destination => destination.ShowType, operation => operation.MapFrom(source => Enum.Parse(typeof(ShowType), source.ShowType.ToString())));
        }
    }
}
