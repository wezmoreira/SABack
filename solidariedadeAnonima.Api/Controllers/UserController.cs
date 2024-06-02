using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.UserCommand;
using solidariedadeAnonima.Domain.Handlers.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace solidariedadeAnonima.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        [HttpGet("account/{id}/v1")]
        public async Task<GenericCommandResult> GetUserAsync(
            [FromRoute] Guid id,
            [FromServices] UserHandler handler)
        {
            return await handler.GetUserAsync(id);
        }

        [HttpGet("all/accounts/v1")]
        [Authorize]
        public async Task<GenericCommandResult> GetAllUsersAsync(
            [FromServices] UserHandler handler)
        {
            return await handler.GetAllUsersAsync();
        }

        [HttpPut("account-update/v1")]
        public async Task<GenericCommandResult> UpdateUserAsync(
            [FromServices] UserHandler handler,
            [FromBody] UpdateUserCommand command)
        {
            return await handler.HandleAsync(command);
        }

        [HttpGet("account/v1")]
        public async Task<GenericCommandResult> GetUserAsync(
            [FromServices] UserHandler handler)
        {
            var userId = GetUserIdToken();
            var result = await handler.FindByIdAsync(userId);

            return await handler.FindByIdAsync(userId);

        }

        private string GetUserIdToken()
        {
            var handlers = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handlers.ReadToken(authHeader);
            var tokenS = handlers.ReadToken(authHeader) as JwtSecurityToken;
            //var email = tokenS.Claims.First(claim => claim.Type == "email").Value;
            return tokenS.Claims.First(claim => claim.Type == "actort").Value;
        }
    }
}
