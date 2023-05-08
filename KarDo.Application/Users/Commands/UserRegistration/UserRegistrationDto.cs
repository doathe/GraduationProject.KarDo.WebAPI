using AutoMapper;
using KarDo.Domain.AggregateModels.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Users.Commands.UserRegistration
{
    public class UserRegistrationDto
    {
        public string Message { get; set; }
        public UserRegistrationDto()
        {
            Message = "Registration Successfull";
        }
    }
    public class UserRegistrationProfile : Profile
    {
        public UserRegistrationProfile()
        {
            CreateMap<UserRegistrationCommand, UserRegistrationDto>().ReverseMap();
            CreateMap<UserRegistrationCommand, ApplicationUser>().ReverseMap();
        }
    }
}
