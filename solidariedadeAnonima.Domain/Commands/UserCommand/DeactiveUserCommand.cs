using Flunt.Notifications;
using Flunt.Validations;
using solidariedadeAnonima.Domain.Commands.Contracts;

namespace solidariedadeAnonima.Domain.Commands.UserCommand
{
    public class DeactiveUserCommand : Notifiable, ICommand
    {
        public string Email { get; private set; }
        public string Username { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Email, "Email", "Email é obrigatório")
                .IsNotNullOrEmpty(Username, "Username", "Username é obrigatório")
                );
        }
    }
}
