using AutoMapper;
using KarDo.Application.Users.Commands.UserRegistration;
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
        public ApplicationUserToken TokenInfo { get; set; }
        public string Message { get; set; }
        public UserLoginDto(ApplicationUserToken tokenInfo)
        {
            Message = "Login successfull";
            TokenInfo = tokenInfo;
        }
    }
    public class UserLoginProfile : Profile
    {
        public UserLoginProfile()
        {
            CreateMap<UserLoginCommand, UserLoginDto>().ReverseMap();
            CreateMap<UserLoginCommand, ApplicationUser>().ReverseMap();
        }
    }
}
