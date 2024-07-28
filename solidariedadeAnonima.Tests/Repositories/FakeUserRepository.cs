using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Tests.Repositories
{
    public class FakeUserRepository : IUserRepository
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

        public Task<User> FindByIdAsync(string id)
        {
            return Task.FromResult(User);
        }

        public Task<IList<User>> GetAllUsersAsync()
        {
            //var newListUser = new List<User> { User };
            var newListUser = new List<User>();
            return Task.FromResult((IList<User>)newListUser);
        }

        public Task<User> GetUserAsync(Guid id)
        {
            return Task.FromResult(User);
        }

        public Task<User> GetUserEmail(string email)
        {
            User.Password = JwtProvider.HashPassword(User.Password);
            return Task.FromResult(User);
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
