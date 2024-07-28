using Microsoft.AspNetCore.Mvc;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.UserCommand;
using solidariedadeAnonima.Domain.Dto;
using solidariedadeAnonima.Domain.Handlers.Pages;

namespace solidariedadeAnonima.Api.Controllers
{
    [ApiController]
    [Route("api/signup")]
    public class RegisterController : ControllerBase
    {
        [HttpPost("v1")]
        public async Task<GenericCommandResult> CreateUserAsync(
            [FromBody] CreateUserCommand command,
            [FromServices] RegisterHandler handler)
        {
            return await handler.HandleAsync(command);
        }
    }
}
