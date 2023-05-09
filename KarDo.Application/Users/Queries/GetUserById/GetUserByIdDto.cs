using AutoMapper;
using KarDo.Domain.AggregateModels.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Users.Queries.GetUserById
{
    public class GetUserByIdDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
    public class GetUserByIdProfile : Profile
    {
        public GetUserByIdProfile()
        {
            CreateMap<GetUserByIdQuery, GetUserByIdDto>().ReverseMap();
            CreateMap<GetUserByIdQuery, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, GetUserByIdDto>()
                .ForMember(destination => destination.FullName, operation => operation.MapFrom(source => source.FirstName + " " + source.LastName))
                .ForMember(destination => destination.UserName, operation => operation.MapFrom(source => source.UserName))
                .ForMember(destination => destination.Email, operation => operation.MapFrom(source => source.Email));
        }
    }
}
