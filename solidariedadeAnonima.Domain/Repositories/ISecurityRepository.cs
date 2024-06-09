using solidariedadeAnonima.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Domain.Repositories
{
    public interface ISecurityRepository
    {
        Task<User> login(string email, string password, CancellationToken cancellationToken = default);
    }
}
