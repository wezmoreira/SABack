using Microsoft.EntityFrameworkCore;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Infra.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        public SecurityRepository(DataContext context)
        {
            _dataContext = context;
        }

        private readonly DataContext _dataContext;

        public async Task<User> login(string email, string password, CancellationToken cancellationToken = default)
        {
            var result = await _dataContext.Users
                .FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower() 
                && x.Password == password);

            return result;
        }
    }
}
