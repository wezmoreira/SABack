using solidariedadeAnonima.Domain.Dto;
using solidariedadeAnonima.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Domain.Repositories
{
    public interface IRegisterRepository
    {
        Task CreateUserAsync(User user);
        Task DeactivateUser(UserDto user); // TODO mudar pra user
    }
}
