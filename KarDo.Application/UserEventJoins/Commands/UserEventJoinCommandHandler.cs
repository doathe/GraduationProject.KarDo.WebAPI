using AutoMapper;
using KarDo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.UserEventJoins.Commands
{
    public class UserEventJoinCommandHandler : IRequestHandler<UserEventJoinCommand, UserEventJoinDto>
    {
        //private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public Task<UserEventJoinDto> Handle(UserEventJoinCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
