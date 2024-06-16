using Microsoft.AspNetCore.Http;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.Comment;
using solidariedadeAnonima.Domain.Handlers.Contracts;
using solidariedadeAnonima.Domain.Repositories;
using System.Security.Claims;
using solidariedadeAnonima.Domain.Entities;

namespace solidariedadeAnonima.Domain.Handlers.Comment
{
    public class CommentHandler : IHandler<CommentCommand>
    {
        public CommentHandler(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, ICommentRepository commentRepository) 
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
        }

        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICommentRepository _commentRepository;

        public async Task<GenericCommandResult> HandleAsync(CommentCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Algo deu errado, não foi possível atualziar o usuário", command);

            var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var user = await _userRepository.GetUserEmail(emailClaim);
            if (user == null)
                return new GenericCommandResult(false, "Algo deu errado, não foi possível recuperar o usuário", null);

            var comment = new Comments(command.Comment, user.Id, command.CardId);

            await _commentRepository.AddCommentAsync(comment);

            return new GenericCommandResult(true, "Comentário adicionado com sucesso", command.Comment);
        }
    }
}
