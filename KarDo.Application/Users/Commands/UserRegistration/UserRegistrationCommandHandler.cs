using AutoMapper;
using KarDo.Domain.AggregateModels.UserAggregate;
using KarDo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Users.Commands.UserRegistration
{
    public class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, UserRegistrationDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserRegistrationCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserRegistrationDto> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {
            var emailExistCheck = await _userRepository.EmailExistCheckAsync(request.Email);
            if (emailExistCheck)
            {
                throw new ApplicationException("You entered the email used");
            }
            var usernameExistCheck = await _userRepository.UsernameExistCheckAsync(request.UserName);
            if (usernameExistCheck)
            {
                throw new ApplicationException("You entered the username used");
            }
            if (request.PasswordHash != request.PasswordVerify)
            {
                throw new ApplicationException("Password verify is not match");
            }

            var model = _mapper.Map<ApplicationUser>(request);
            await _userRepository.AddAsync(model);

            return await Task.FromResult(new UserRegistrationDto());
        }
    }
}
