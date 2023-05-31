using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Events.Queries.GetEventByUserId
{
    public class GetEventByUserIdQuery : IRequest<IEnumerable<GetEventByUserIdDto>>
    {
        [FromBody] // UserId özelliği istekte alınmaz
        public string UserId { get; set; }
    }
}
