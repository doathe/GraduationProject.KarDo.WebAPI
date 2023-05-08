using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Users.Commands.UserLogin
{
    public class UserLoginCommand : IRequest<UserLoginDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
