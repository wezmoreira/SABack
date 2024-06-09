using Microsoft.EntityFrameworkCore;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Infra.Context;

namespace solidariedadeAnonima.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(DataContext context) 
        {
            _context = context;
        }

        private readonly DataContext _context;

        public async Task<User> GetUserAsync(Guid id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return result;
        }

        public async Task<IList<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<User> FindByIdAsync(string id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Id.ToString() == id);
            return result;
        }

        public async Task<User> GetUserEmail(string email)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return result;
        }
    }
}
