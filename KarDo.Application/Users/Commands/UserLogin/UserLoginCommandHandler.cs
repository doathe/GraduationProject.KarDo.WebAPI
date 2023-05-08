using AutoMapper;
using KarDo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Users.Commands.UserLogin
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserLoginDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserLoginCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserLoginDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var userExistCheck = await _userRepository.UsernameExistCheckAsync(request.Username);
            if (!userExistCheck)
            {
                throw new ApplicationException("User not exist");
            }

            var userCheck = await _userRepository.GetByUsernameAsync(request.Username);
            if(request.Password != userCheck.PasswordHash)
            {
                throw new ApplicationException("Password is not correct");
            }

            var token = _userRepository.Authorization(userCheck);

            return await Task.FromResult(new UserLoginDto(token));
        }
    }
}
