using AutoMapper;
using KarDo.Application.Users.Commands.UserRegistration;
using KarDo.Domain.AggregateModels.UserAggregate;
using KarDo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Users.Commands.UserUpdate
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, UserUpdateDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserUpdateCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserUpdateDto> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var updateModel = _mapper.Map<ApplicationUser>(request);
            await _userRepository.UpdateUserAsync(updateModel, request.UserId);

            return await Task.FromResult(new UserUpdateDto());
        }
    }
}
