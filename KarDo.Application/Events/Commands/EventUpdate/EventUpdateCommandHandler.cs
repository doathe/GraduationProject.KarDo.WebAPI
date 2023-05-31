using AutoMapper;
using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Commands.EventUpdate
{
    public class EventUpdateCommandHandler : IRequestHandler<EventUpdateCommand, EventUpdateDto>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventUpdateCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<EventUpdateDto> Handle(EventUpdateCommand request, CancellationToken cancellationToken)
        {
            var updateModel = _mapper.Map<Event>(request);
            await _eventRepository.UpdateEventAsync(updateModel, request.EventId);

            return await Task.FromResult(new EventUpdateDto());
        }
    }
}
