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
        //IHandler<DeactiveUserCommand>
    {

        public RegisterHandler(IRegisterRepository repository, IJwtProvider provider)
        {
            _repository = repository;
        }

        private readonly IRegisterRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public async Task<GenericCommandResult> HandleAsync(CreateUserCommand command)
        {
            try
            {
                command.Validate();
                if (command.Invalid)
                    return new GenericCommandResult(false, "Algo deu errado, não foi possível criar usuáriuo", command.Notifications);

                var hashPassword = JwtProvider.HashPassword(command.Password);

                var user = new User(command.Email, command.Username, hashPassword, 
                    command.City, command.Address, command.Cep, command.Number);

                await _repository.CreateUserAsync(user);

                return new GenericCommandResult(true, "Usuario criado com sucesso", true);  // TODO - terminar
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro 500", ex.Message);
            }
        }

        //public async Task<GenericCommandResult> HandleAsync(DeactiveUserCommand command)
        //{
        //    command.Validate();
        //    if(command.Invalid)
        //        return new GenericCommandResult(false, "Algo deu errado, Não foi possível desativar usuário", command.Notifications);

        //    var result = _userRepository.FindAsync(command.Username, command.Email);

        //    //TODO - Terminar 
        //}
    }
}
