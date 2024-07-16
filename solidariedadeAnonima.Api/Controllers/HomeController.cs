using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.HomeCommand;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Enums;
using solidariedadeAnonima.Domain.Handlers.Pages;
using solidariedadeAnonima.Domain.Security;

namespace solidariedadeAnonima.Api.Controllers
{
    [ApiController]
    [Route("api/v1/cards")]
    public class HomeController : ControllerBase
    {
        [HttpGet("principal")]
        [AllowAnonymous]
        public async Task<GenericCommandResult> GetCardsAsync(
            [FromServices] HomeHandler handler)
        {
            return await handler.GetAllPrincipalCardsAsync();
        }

        [HttpPost("new-card")]
        [HasPermission(Permissions.User)]
        public async Task<GenericCommandResult> AddNewCardAsync(
            [FromBody] CreateCardCommand command,
            [FromServices] HomeHandler handler)
        {
            return await handler.HandleAsync(command);
        }


        [HttpGet("teste")]
        [Authorize]
        public async Task<IActionResult> Teste()
        {
            var result = "Estou autorizado";
            return Ok(result);
        }

    }
}
