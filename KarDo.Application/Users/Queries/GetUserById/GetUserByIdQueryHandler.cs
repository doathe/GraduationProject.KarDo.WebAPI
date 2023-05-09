using AutoMapper;
using KarDo.Domain.AggregateModels.UserAggregate;
using KarDo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserByIdDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userModel = await _userRepository.GetByIdAsync(request.Id);
            if (userModel == null)
            {
                throw new Exception("User not found");
            }
            var responseModel = _mapper.Map<GetUserByIdDto>(userModel);
            return responseModel;
        }
    }
}
