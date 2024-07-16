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

        [HttpGet("load-comments")]
        public async Task<GenericCommandResult> GetCommentsAsync(
            [FromServices] CommentHandler handler)
        {
            return await handler.HandleAsync();
        }


        [HttpPost("new-comment")]
        public async Task<GenericCommandResult> AddNewCommentAsync(
            [FromBody] CommentCommand command,
            [FromServices] CommentHandler handler)
        {
            return await handler.HandleAsync(command);
        }
    }
}
