using solidariedadeAnonima.Domain.Dto;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Infra.Context;

namespace solidariedadeAnonima.Infra.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        public RegisterRepository(DataContext context)
        {
            _dataContext = context;
        }

        private readonly DataContext _dataContext;

        public async Task CreateUserAsync(User user)
        {
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
        }

        public Task DeactivateUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
