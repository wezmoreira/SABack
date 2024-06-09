using Flunt.Notifications;
using Flunt.Validations;
using solidariedadeAnonima.Domain.Commands.Contracts;

namespace solidariedadeAnonima.Domain.Commands.Security.Login
{
    public class LoginCommand : Notifiable, ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Email, "Email", "Email é obrigatório")
                .IsNotNullOrEmpty(Password, "Password", "Password é obrigatório")
                );
        }
    }
}
