using AutoMapper;
using KarDo.Application.Events.Queries.GetEventAll;
using KarDo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Queries.GetEventByUserId
{
    public class GetEventByUserIdQueryHandler : IRequestHandler<GetEventByUserIdQuery, IEnumerable<GetEventByUserIdDto>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventByUserIdQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetEventByUserIdDto>> Handle(GetEventByUserIdQuery request, CancellationToken cancellationToken)
        {
            var allEvent = await _eventRepository.GetEventByUserIdAsync(request.UserId);
            List<GetEventByUserIdDto> responseModelList = new List<GetEventByUserIdDto>();

            foreach (var item in allEvent)
            {
                var responseModel = _mapper.Map<GetEventByUserIdDto>(item);
                responseModelList.Add(responseModel);
            }

            return await Task.FromResult(responseModelList);
        }
    }
}
