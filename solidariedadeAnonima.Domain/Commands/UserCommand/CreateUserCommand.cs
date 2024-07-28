using Flunt.Notifications;
using Flunt.Validations;
using solidariedadeAnonima.Domain.Commands.Contracts;

namespace solidariedadeAnonima.Domain.Commands.UserCommand
{
    public class CreateUserCommand : Notifiable, ICommand
    {

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
        public string Number { get; set; }


        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Email, 2, "Email", "O email precisa ter mais do que 2 caracteres.") // TODO adicionar a validação de email com regex
                .HasMinLen(Username, 3, "Username", "O Username precisa ter mais do que 3 caracteres")
                .HasMaxLen(Username, 15, "Username", "O Username deve ter menos que 15 caracteres")
                .HasMinLen(Password, 5, "Password", "O Password precisa ter mais do que 5 caracteres")
                .HasMaxLen(Password, 35, "Password", "O Password deve ter menos que 35 caracteres")
                );
        }
    }
}
