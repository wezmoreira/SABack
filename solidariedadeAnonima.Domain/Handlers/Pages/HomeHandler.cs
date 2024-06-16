using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.HomeCommand;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Handlers.Contracts;
using solidariedadeAnonima.Domain.Repositories;
using System.Security.Claims;

namespace solidariedadeAnonima.Domain.Handlers.Pages
{
    public class HomeHandler : IHandler<CreateCardCommand>
    {
        public HomeHandler(IHomeRepository repository, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
            _userRepository = userRepository;
        }

        private readonly IHomeRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public async Task<GenericCommandResult> GetAllPrincipalCardsAsync()
        {
            var result = await _repository.GetPrincipalsCardsAsync();
            if (result == null)
                return new GenericCommandResult(false, "Algo deu errado", null);

            return new GenericCommandResult(true, "Cards retornados com sucesso", result);
        }

        public async Task<GenericCommandResult> HandleAsync(CreateCardCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Payload inválido", command.Notifications);

            try
            {
                var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                var user = await _userRepository.GetUserEmail(emailClaim);
                if (user == null)
                    return new GenericCommandResult(false, "Algo deu errado, não foi possível recuperar o usuário", null);

                var card = new CardPrincipal(command.Title, command.Description, command.ImageLarge,
                    command.ImageOriginal, command.ImagePortrait, command.ImageLandscape, command.ImageTiny, user.Id);

                await _repository.AddCardAsync(card);

                return new GenericCommandResult(true, "Cards retornados com sucesso", card);
            }
            catch
            {
                return new GenericCommandResult(false, "Algo deu errado, não foi possível criar um novo card", null);
            }
        }
    }
}
