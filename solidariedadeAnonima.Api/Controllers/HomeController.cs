using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.HomeCommand;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Handlers.Pages;

namespace solidariedadeAnonima.Api.Controllers
{
    [ApiController]
    [Route("api/v1/cards")]
    public class HomeController : ControllerBase
    {

        //[HttpGet("principal")]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetCardsAsync(
        //    [FromServices] HomeHandler handler)
        //{
        //    var result = new List<CardPrincipal>();
        //    result.Add(new CardPrincipal("Title", "Description", null));
        //    result.Add(new CardPrincipal("Title", "Description", null));

        //    result.Add(new CardPrincipal("Title", "Description", null));

        //    //var result = await handler.GetAllPrincipalCardsAsync();

        //    return Ok(result);
        //}

        [HttpGet("principal")]
        [AllowAnonymous]
        public async Task<GenericCommandResult> GetCardsAsync(
            [FromServices] HomeHandler handler)
        {
            return await handler.GetAllPrincipalCardsAsync();
        }

        [HttpPost("new-card")]
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
