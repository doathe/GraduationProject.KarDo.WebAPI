using AutoMapper;
using KarDo.Application.Events.Commands.EventCreate;
using KarDo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Queries.GetEventAll
{
    public class GetEventAllQueryHandler : IRequestHandler<GetEventAllQuery, IEnumerable<GetEventAllDto>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventAllQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetEventAllDto>> Handle(GetEventAllQuery request, CancellationToken cancellationToken)
        {
            var allEvent = await _eventRepository.GetEventAllAsync();
            List<GetEventAllDto> responseModelList = new List<GetEventAllDto>();

            foreach (var item in allEvent)
            {
                var responseModel = _mapper.Map<GetEventAllDto>(item);
                responseModelList.Add(responseModel);
            }

            return await Task.FromResult(responseModelList);
        }
    }
}
