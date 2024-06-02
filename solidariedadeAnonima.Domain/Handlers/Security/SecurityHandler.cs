using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.Security;
using solidariedadeAnonima.Domain.Handlers.Contracts;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Domain.Handlers.Security
{
    public class SecurityHandler : IHandler<SecurityCommand>
    {
        public SecurityHandler(ISecurityRepository repository)
        {
            _securityRepository = repository;
        }

        private readonly ISecurityRepository _securityRepository;

        public async Task<GenericCommandResult> HandleAsync(SecurityCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Algo deu errado", command.Notifications);

            var result = await _securityRepository.login(command.Email, command.Password);
            if(result == null)
                return new GenericCommandResult(false, "Usuário não existe!", null);

            var token = TokenService.GenerateToken(result);

            return new GenericCommandResult(true, "Login realizado com sucesso!", token);
        }
    }
}
