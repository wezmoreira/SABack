using Flunt.Notifications;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.UserCommand;
using solidariedadeAnonima.Domain.Dto;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Handlers.Contracts;
using solidariedadeAnonima.Domain.Interfaces;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Domain.Security;

namespace solidariedadeAnonima.Domain.Handlers.Pages
{
    public class RegisterHandler : 
        IHandler<CreateUserCommand>
    {

        public RegisterHandler(IRegisterRepository repository)
        {
            _repository = repository;
        }

        private readonly IRegisterRepository _repository;

        public async Task<GenericCommandResult> HandleAsync(CreateUserCommand command)
        {
            try
            {
                command.Validate();
                if (command.Invalid)
                    return new GenericCommandResult(false, "Algo deu errado, não foi possível criar usuário", command.Notifications);

                var hashPassword = JwtProvider.HashPassword(command.Password);

                var user = new User(command, hashPassword);

                await _repository.CreateUserAsync(user);

                return new GenericCommandResult(true, "Usuario criado com sucesso", true);  // TODO - terminar
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro 500", ex.Message);
            }
        }
    }
}
