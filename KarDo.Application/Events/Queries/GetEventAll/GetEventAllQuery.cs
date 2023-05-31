using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Queries.GetEventAll
{
    public class GetEventAllQuery : IRequest<IEnumerable<GetEventAllDto>>
    {

    }
}
