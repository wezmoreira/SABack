using solidariedadeAnonima.Domain.Commands.UserCommand;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Runtime.ConstrainedExecution;

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

        public User(CreateUserCommand command, string hashPassword)
        {
            Email = command.Email;
            Username = command.Username;
            Password = hashPassword;
            City = command.City;
            State = command.State;
            Address = command.Address;
            Cep= command.Cep;
            Number = command.Number;
            Role = "User";
            Active = true;
        }

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string State { get; set; }
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

        public void UserFilter()
        {
            Password = "";
        }
    }
}
