using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdDto>
    {
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
