using solidariedadeAnonima.Domain.Dto;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Tests.Repositories
{
    internal class FakeRegisterRepository : IRegisterRepository
    {
        private readonly User User = new User
        {
            Email = "wesley@email.com",
            Username = "wesley",
            Password = "123456",
            City = "São Paulo",
            Address = "Rua dos Bobos",
            Cep = "123456",
            Number = "123",
            Role = "User",
            Active = true
        };

        public Task CreateUserAsync(User user)
        {
            return Task.FromResult(User);
        }

        public Task DeactivateUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
