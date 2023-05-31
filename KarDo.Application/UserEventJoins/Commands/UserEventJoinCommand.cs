﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Application.UserEventJoins.Commands
{
    public class UserEventJoinCommand : IRequest<UserEventJoinDto>
    {
        public string UserId { get; set; }
        public string EventId { get; set; }
        public bool IsJoined { get; set; }
    }
}