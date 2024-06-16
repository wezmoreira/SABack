using Microsoft.AspNetCore.Mvc;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.Comment;
using solidariedadeAnonima.Domain.Handlers.Comment;

namespace solidariedadeAnonima.Api.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {

        [HttpPost("new-comment")]
        public async Task<GenericCommandResult> AddNewCard(
            [FromBody] CommentCommand command,
            [FromServices] CommentHandler handler)
        {
            return await handler.HandleAsync(command);
        }
    }
}
