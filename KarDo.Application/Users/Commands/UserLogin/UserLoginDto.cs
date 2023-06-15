using AutoMapper;
using KarDo.Domain.AggregateModels.UserAggregate;
using KarDo.Domain.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Users.Commands.UserLogin
{
    public class UserLoginDto
    {
        public string token { get; set; }
        //public TokenInfo TokenInfo { get; set; }
        //public string Message { get; set; }
        //public UserLoginDto(TokenInfo tokenInfo)
        //{
        //    Message = "Login successfull";
        //    TokenInfo = tokenInfo;
        //}
    }
    public class UserLoginProfile : Profile
    {
        public UserLoginProfile()
        {
            CreateMap<UserLoginCommand, UserLoginDto>().ReverseMap();
            CreateMap<UserLoginCommand, ApplicationUser>().ReverseMap();
            CreateMap<UserLoginDto, TokenInfo>().ReverseMap()
                .ForMember(destination => destination.token, operation => operation.MapFrom(source => source.Token));
        }
    }
}
