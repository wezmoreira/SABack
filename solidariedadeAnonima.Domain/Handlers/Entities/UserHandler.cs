using solidariedadeAnonima.Domain.Commands.UserCommand;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Domain.Handlers.Contracts;

namespace solidariedadeAnonima.Domain.Handlers.Entities
{
    public class UserHandler : IHandler<UpdateUserCommand>
    {
        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private readonly IUserRepository _userRepository;

        public async Task<GenericCommandResult> GetUserAsync(Guid userId)
        {
            try
            {
                var user = await _userRepository.GetUserAsync(userId);
                if (user == null)
                    return new GenericCommandResult(false, "Algo deu errado, não foi possível recuperar o usuário", null);

                return new GenericCommandResult(true, "Usuario recuperado com sucesso", new {Username = user.Username, Email = user.Email, Active = user.Active});
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro 500", ex.Message);
            }
        }

        public async Task<GenericCommandResult> FindByIdAsync(string userId)
        { // refazer
            try
            {
                var user = await _userRepository.FindByIdAsync(userId);
                if (user == null)
                    return new GenericCommandResult(false, "Algo deu errado, não foi possível recuperar o usuário", null);

                user.Password = "";

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
                var user = await _userRepository.GetUserAsync(command.Id);
                if(user == null)
                    return new GenericCommandResult(false, "O usuario não existe!", null);

                user.Update(command);

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