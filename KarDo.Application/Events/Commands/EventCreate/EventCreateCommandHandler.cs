using AutoMapper;
using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Commands.EventCreate
{
    public class EventCreateCommandHandler : IRequestHandler<EventCreateCommand, EventCreateDto>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventCreateCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<EventCreateDto> Handle(EventCreateCommand request, CancellationToken cancellationToken)
        {
            var eventModel = _mapper.Map<Event>(request);
            await _eventRepository.AddAsync(eventModel);

            return await Task.FromResult(new EventCreateDto());
        }
    }
}
