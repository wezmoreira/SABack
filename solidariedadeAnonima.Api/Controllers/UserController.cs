using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.UserCommand;
using solidariedadeAnonima.Domain.Handlers.Entities;
using solidariedadeAnonima.Domain.Security;
using solidariedadeAnonima.Domain.Enums;

namespace solidariedadeAnonima.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        [HttpGet("account/{id}/v1")]
        [HasPermission(Permissions.User)]
        public async Task<GenericCommandResult> GetUserAsync(
            [FromRoute] Guid id,
            [FromServices] UserHandler handler)
        {
            return await handler.GetUserAsync(id);
        }

        [HttpGet("all/accounts/v1")]
        [HasPermission(Permissions.Admin)]
        public async Task<GenericCommandResult> GetAllUsersAsync(
            [FromServices] UserHandler handler)
        {
            return await handler.GetAllUsersAsync();
        }

        [HttpPut("account-update/v1")]
        [HasPermission(Permissions.User)]
        public async Task<GenericCommandResult> UpdateUserAsync(
            [FromServices] UserHandler handler,
            [FromBody] UpdateUserCommand command)
        {
            return await handler.HandleAsync(command);
        }

        [HttpGet("account/v1")]
        [HasPermission(Permissions.User)]
        public async Task<GenericCommandResult> GetUserAsync(
            [FromServices] UserHandler handler)
        {
            return await handler.FindByEmail();
        }
    }
}
