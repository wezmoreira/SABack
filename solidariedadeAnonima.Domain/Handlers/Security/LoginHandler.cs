using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.Security.Login;
using solidariedadeAnonima.Domain.Handlers.Contracts;
using solidariedadeAnonima.Domain.Interfaces;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Domain.Security;
using solidariedadeAnonima.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
                return null; // TODO - refatorar

            var user = await _userRepository.GetUserEmail(request.Email);

            if (user == null)
                return null;

            var validUser = JwtProvider.VerifyPassword(request.Password, user.Password);
            if (!validUser)
                return null;

            var result = await _securityRepository.login(request.Email, user.Password);

            if (result == null)
                return null; // TODO - refatorar


            var token = _jwtProvider.Generate(result);

            return token;
        }
    }
}
