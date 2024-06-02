using solidariedadeAnonima.Domain.Entities;

namespace solidariedadeAnonima.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(Guid id);
        Task<IList<User>> GetAllUsersAsync();
        Task<User> FindByIdAsync(string id);
        Task UpdateUserAsync(User user);
    }
}
