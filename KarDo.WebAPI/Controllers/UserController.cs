using KarDo.Application.Users.Commands.UserLogin;
using KarDo.Application.Users.Commands.UserRegistration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KarDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(UserLoginCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(UserRegistrationCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
