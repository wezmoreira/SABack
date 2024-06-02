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

        //[HttpPut]
        //public async Task<GenericCommandResult> DeactiveUser(
        //    [FromServices] RegisterHandler handler,
        //    [FromBody] DeactiveUserCommand user)
        //{
        //    //var result = await handler.DeactivateUserAsync(user);
        //    //return result;
        //}

        [HttpGet("v1/health")]
        public async Task<IActionResult> CreateUserAsync()
        {
            return Ok("Funcionando");
        }
    }
}
