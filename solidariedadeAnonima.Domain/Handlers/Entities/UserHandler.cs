using solidariedadeAnonima.Domain.Commands.UserCommand;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Domain.Handlers.Contracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace solidariedadeAnonima.Domain.Handlers.Entities
{
    public class UserHandler : IHandler<UpdateUserCommand>
    {
        public UserHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public async Task<GenericCommandResult> GetUserAsync(Guid userId)
        {
            try
            {
                var user = await _userRepository.GetUserAsync(userId);
                if (user == null)
                    return new GenericCommandResult(false, "Algo deu errado, não foi possível recuperar o usuário", null);

                user.UserFilter();

                return new GenericCommandResult(true, "Usuario recuperado com sucesso", user);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro 500", ex.Message);
            }
        }

        public async Task<GenericCommandResult> FindByEmail()
        { // refazer
            try
            {
                var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                var user = await _userRepository.GetUserEmail(emailClaim);
                if (user == null)
                    return new GenericCommandResult(false, "Algo deu errado, não foi possível recuperar o usuário", null);

                user.UserFilter();

                return new GenericCommandResult(true, "Usuario recuperado com sucesso", user);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro 500", ex.Message);
            }
        }

        public async Task<GenericCommandResult> GetAllUsersAsync()
        {
            try
            {
                var user = await _userRepository.GetAllUsersAsync();

                return new GenericCommandResult(true, "Usuario recuperado com sucesso", user);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro 500", ex.Message);
            }
        }

        public async Task<GenericCommandResult> HandleAsync(UpdateUserCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Algo deu errado, não foi possível atualziar o usuário", command);

            try
            {
                var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                var user = await _userRepository.GetUserEmail(emailClaim);
                if (user == null)
                    return new GenericCommandResult(false, "Algo deu errado, não foi possível recuperar o usuário", null);

                user.Update(command.UpdatedFields);

                await _userRepository.UpdateUserAsync(user);

                return new GenericCommandResult(true, "Usuário atualizado com sucesso!", new { Email = user.Email, UserName = user.Username });
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro 500", ex.Message);
            }
        }
    }
}