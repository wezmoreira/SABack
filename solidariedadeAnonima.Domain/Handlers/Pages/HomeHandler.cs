using Flunt.Notifications;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.HomeCommand;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Handlers.Contracts;
using solidariedadeAnonima.Domain.Repositories;

namespace solidariedadeAnonima.Domain.Handlers.Pages
{
    public class HomeHandler : IHandler<CreateCardCommand>
    {
        public HomeHandler(IHomeRepository repository)
        {
            _repository = repository;
        }

        private readonly IHomeRepository _repository;


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
                var card = new CardPrincipal(command.Title, command.Description, command.ImageLarge,
                    command.ImageOriginal, command.ImagePortrait, command.ImageLandscape, command.ImageTiny);

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
