using AutoMapper;
using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.AggregateModels.UserEventJoinAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.UserEventJoins.Commands
{
    public class UserEventJoinDto
    {

    }
    public class UserEventJoinProfile : Profile
    {
        public UserEventJoinProfile()
        {
            CreateMap<UserEventJoinCommand, UserEventJoinDto>().ReverseMap();
            CreateMap<UserEventJoinDto, UserEventJoin>().ReverseMap();
            CreateMap<UserEventJoinCommand, UserEventJoin>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => Guid.Parse(src.EventId)));

            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));
        }
    }
}
