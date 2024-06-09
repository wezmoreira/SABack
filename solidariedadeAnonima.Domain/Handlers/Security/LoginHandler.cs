using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.Security.Login;
using solidariedadeAnonima.Domain.Handlers.Contracts;
using solidariedadeAnonima.Domain.Interfaces;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Domain.Security;

namespace solidariedadeAnonima.Domain.Handlers.Security
{
    public class LoginHandler : IHandler<LoginCommand, string>
    {
        public LoginHandler(ISecurityRepository securityRepository,
            IJwtProvider provider, IUserRepository userRepository)
        {
            _securityRepository = securityRepository;
            _jwtProvider = provider;
            _userRepository = userRepository;
        }
        
        private readonly IJwtProvider _jwtProvider;
        private readonly ISecurityRepository _securityRepository;
        private readonly IUserRepository _userRepository;

        public async Task<GenericCommandResult> HandleAsync(LoginCommand command, CancellationToken cancellationToken)
        {
            if (command.Invalid)
                return new GenericCommandResult(false, "Algo deu errado", command.Notifications);

            var user = await _userRepository.GetUserEmail(command.Email);
            if (user == null)
                return new GenericCommandResult(false, "Usuário não encontrado", null);

            var validUser = JwtProvider.VerifyPassword(command.Password, user.Password);
            if (!validUser)
                return new GenericCommandResult(false, "Usuário invalido!", null);

            var result = await _securityRepository.login(command.Email, user.Password);
            if (result == null)
                return new GenericCommandResult(false, "Não foi possível realizar o login.", null);


            var token = _jwtProvider.Generate(result);

            return new GenericCommandResult(true, "Login realizado com Sucesso!", token);
        }
    }
}
