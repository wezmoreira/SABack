using solidariedadeAnonima.Domain.Commands.UserCommand;

namespace solidariedadeAnonima.Domain.Entities
{
    public class User : Entity
    {
        public User(string email, string username, string password, string city, string address, string cep, string number)
        {
            Email = email;
            Username = username;
            Password = password;
            City = city;
            Address = address;
            Cep = cep;
            Number = number;
            Role = "User";
            Active = true;
        }

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Cep { get; set; }
        public string Number { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }

        public void ActiveUser()
        {
            Active = true;
        }

        public void DeactiveUser()
        {
            Active = false;
        }

        public void Update(UpdateUserCommand command)
        {
            Email = command.Email;
            Username = command.Username;
            Password = command.Password;
        }

    }
}
