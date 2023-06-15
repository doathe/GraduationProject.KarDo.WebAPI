
using KarDo.Application.Events.Commands.EventCreate;
using KarDo.Application.Events.Commands.EventDelete;
using KarDo.Application.Events.Commands.EventUpdate;
using KarDo.Application.Events.Queries.GetEventAll;
using KarDo.Application.Events.Queries.GetEventByUserId;
using KarDo.Application.UserEventJoins.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KarDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EventController(IMediator mediator, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            this.mediator = mediator;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpPost]
        [Route("create-event")]
        public async Task<IActionResult> EventCreate(EventCreateCommand command)
        {
            var authHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authHeader) && authHeader.ToString().StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.ToString()[7..];

                try
                {
                    // Token'ı çözümle
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = _config["Application:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = _config["Application:Audience"],
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    // Token içindeki claim'leri oku
                    var jwtToken = (JwtSecurityToken)validatedToken;
                    var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value;

                    if (userId != null)
                    {
                        command.UserId = userId.ToString();
                        var result = await mediator.Send(command);
                        return new JsonResult(result);
                    }
                    else
                    {
                        return BadRequest("Invalid user ID.");
                    }
                }
                catch (SecurityTokenExpiredException)
                {
                    return BadRequest("Token has expired.");
                }
                catch (SecurityTokenInvalidSignatureException)
                {
                    return BadRequest("Invalid token signature.");
                }
                catch (SecurityTokenException)
                {
                    return BadRequest("Invalid token.");
                }
            }
            return BadRequest("Invalid authorization header.");
        }
        
        [Authorize]
        [HttpDelete]
        [Route("delete-event")]
        public async Task<IActionResult> EventDelete(EventDeleteCommand command)
        {
            return new JsonResult(await mediator.Send(command));
        }

        [Authorize]
        [HttpPut]
        [Route("update-event")]
        public async Task<IActionResult> EventUpdate(EventUpdateCommand command)
        {
            return new JsonResult(await mediator.Send(command));
        }

        [Authorize]
        [HttpGet]
        [Route("get-event-all")]
        public async Task<IActionResult> GetEventAll()
        {
            return new JsonResult(await mediator.Send(new GetEventAllQuery()));
        }

        [Authorize]
        [HttpGet]
        [Route("get-event-by-user-id")]
        public async Task<IActionResult> GetEventByUserId()
        {
            var authHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authHeader) && authHeader.ToString().StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.ToString()[7..];

                try
                {
                    // Token'ı çözümle
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = _config["Application:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = _config["Application:Audience"],
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    // Token içindeki claim'leri oku
                    var jwtToken = (JwtSecurityToken)validatedToken;
                    var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value;

                    if (userId != null)
                    {
                        var query = new GetEventByUserIdQuery();
                        query.UserId = userId.ToString();
                        var result = await mediator.Send(query);
                        return new JsonResult(result);
                    }
                    else
                    {
                        return BadRequest("Invalid user ID.");
                    }
                }
                catch (SecurityTokenExpiredException)
                {
                    return BadRequest("Token has expired.");
                }
                catch (SecurityTokenInvalidSignatureException)
                {
                    return BadRequest("Invalid token signature.");
                }
                catch (SecurityTokenException)
                {
                    return BadRequest("Invalid token.");
                }
            }
            return BadRequest("Invalid authorization header.");
        }

        [Authorize]
        [HttpPost]
        [Route("user-event-join")]
        public async Task<IActionResult> UserEventJoinCreate(UserEventJoinCommand command)
        {
            var authHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authHeader) && authHeader.ToString().StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.ToString()[7..];

                try
                {
                    // Token'ı çözümle
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = _config["Application:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = _config["Application:Audience"],
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    // Token içindeki claim'leri oku
                    var jwtToken = (JwtSecurityToken)validatedToken;
                    var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value;

                    if (userId != null)
                    {
                        command.UserId = userId.ToString();
                        var result = await mediator.Send(command);
                        return new JsonResult(result);
                    }
                    else
                    {
                        return BadRequest("Invalid user ID.");
                    }
                }
                catch (SecurityTokenExpiredException)
                {
                    return BadRequest("Token has expired.");
                }
                catch (SecurityTokenInvalidSignatureException)
                {
                    return BadRequest("Invalid token signature.");
                }
                catch (SecurityTokenException)
                {
                    return BadRequest("Invalid token.");
                }
            }
            return BadRequest("Invalid authorization header.");
        }
    }
}
