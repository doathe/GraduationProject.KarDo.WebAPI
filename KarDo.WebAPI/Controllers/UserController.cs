using KarDo.Application.Users.Commands.UserLogin;
using KarDo.Application.Users.Commands.UserRegistration;
using KarDo.Application.Users.Queries.GetUserById;
using KarDo.Infrastructure.EFCore.Library;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KarDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IMediator mediator, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            this.mediator = mediator;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
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

        [Authorize]
        [HttpGet]
        //[Route("{id}")]
        public async Task<IActionResult> GetUserById()
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
                        // userId kullanarak kullanıcıyı bulabilirsiniz
                        var result = await mediator.Send(new GetUserByIdQuery(userId.ToString()));
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
