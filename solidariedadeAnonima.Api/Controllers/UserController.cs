using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.UserCommand;
using solidariedadeAnonima.Domain.Handlers.Entities;

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

        [Authorize]
        [HttpGet("account/v1")]
        public async Task<GenericCommandResult> GetUserAsync(
            [FromServices] UserHandler handler)
        {
            return await handler.FindByEmail();
        }
    }
}
