using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Commands.EventUpdate
{
    public class EventUpdateCommandValidator : AbstractValidator<EventUpdateCommand>
    {
        public EventUpdateCommandValidator()
        {
            RuleFor(x => x.EventDate)
                .NotEmpty().WithMessage("Event Date is required")
                .InclusiveBetween(new DateTime(2008, 01, 01), new DateTime(2100, 01, 01)).WithMessage("Enter a valid date range");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Event name is required");

            RuleFor(x => x.ShowType)
                .NotEmpty().WithMessage("Show type is required");
        }
    }
}
