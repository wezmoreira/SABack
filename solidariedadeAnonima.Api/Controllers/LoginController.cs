using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.Security;
using solidariedadeAnonima.Domain.Commands.Security.Login;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Handlers.Pages;
using solidariedadeAnonima.Domain.Handlers.Security;

namespace solidariedadeAnonima.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login/v1")]
        [AllowAnonymous]
        public async Task<GenericCommandResult> Authenticate(
            [FromBody] LoginCommand command, 
            [FromServices] LoginHandler handler,
            CancellationToken cancellationToken)
        {
            return await handler.HandleAsync(command, cancellationToken);
        }
    }
}
