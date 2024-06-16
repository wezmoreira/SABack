using Flunt.Notifications;
using Flunt.Validations;
using solidariedadeAnonima.Domain.Commands.Contracts;

namespace solidariedadeAnonima.Domain.Commands.Comment
{
    public class CommentCommand : Notifiable, ICommand
    {
        public string Comment { get; set; }
        public Guid CardId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
             .Requires()
             .HasMinLen(Comment, 5, "Comment", "O Comment precisa ter mais do que 5 caracteres.")
             .HasMaxLen(Comment, 100, "Comment", "O Comment precisa ter menos do que 100 caracteres")
             .IsNotNullOrEmpty(CardId.ToString(), "CardId", "CardId é obrigatório!"));
        }
    }
}
