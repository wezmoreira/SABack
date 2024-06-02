using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Domain.Dto
{
    public class UserDto
    {
        public UserDto(string email, string username)
        {
            Email = email;
            Username = username;
        }

        public string Email { get; private set; }
        public string Username { get; private set; }
    }
}
