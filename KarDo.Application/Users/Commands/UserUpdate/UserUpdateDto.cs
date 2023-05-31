using AutoMapper;
using KarDo.Application.Users.Commands.UserRegistration;
using KarDo.Domain.AggregateModels.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Users.Commands.UserUpdate
{
    public class UserUpdateDto
    {
        public string Message { get; set; }
        public UserUpdateDto()
        {
            Message = "Update Successfull";
        }
        public class UserUpdateProfile : Profile
        {
            public UserUpdateProfile()
            {
                CreateMap<UserUpdateCommand, UserUpdateDto>().ReverseMap();
                CreateMap<UserUpdateCommand, ApplicationUser>().ReverseMap();
            }
        }
    }
}
