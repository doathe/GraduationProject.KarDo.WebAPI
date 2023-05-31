using AutoMapper;
using KarDo.Domain.AggregateModels.EventAggregate;
using KarDo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Commands.EventDelete
{
    public class EventDeleteCommandHandler : IRequestHandler<EventDeleteCommand, EventDeleteDto>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventDeleteCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<EventDeleteDto> Handle(EventDeleteCommand request, CancellationToken cancellationToken)
        {
            var eventModel = _mapper.Map<Event>(request);
            await _eventRepository.DeleteAsync(eventModel.Id.ToString());
            if (eventModel== null)
            {
                throw new ArgumentNullException(nameof(eventModel));
            }

            return await Task.FromResult(new EventDeleteDto());
        }
    }
}
