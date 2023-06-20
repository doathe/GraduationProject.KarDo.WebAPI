using AutoMapper;
using KarDo.Domain.AggregateModels.UserEventJoinAggregate;
using KarDo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.UserEventJoins.Commands
{
    public class UserEventJoinCommandHandler : IRequestHandler<UserEventJoinCommand, IEnumerable<string>>
    {
        private readonly IUserEventJoinRepository _userEventJoinRepository;
        private readonly IMapper _mapper;

        public UserEventJoinCommandHandler(IUserEventJoinRepository userEventJoinRepository, IMapper mapper)
        {
            _userEventJoinRepository = userEventJoinRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> Handle(UserEventJoinCommand request, CancellationToken cancellationToken)
        {
            var requestModel = _mapper.Map<UserEventJoin>(request);
            var responseModel = await _userEventJoinRepository.UserEventJoinCheckAsync(requestModel);

            return await Task.FromResult(responseModel);
        }
    }
}
