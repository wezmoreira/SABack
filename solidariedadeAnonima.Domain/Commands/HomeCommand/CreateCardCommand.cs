using Flunt.Notifications;
using Flunt.Validations;
using solidariedadeAnonima.Domain.Commands.Contracts;

namespace solidariedadeAnonima.Domain.Commands.HomeCommand
{
    public class CreateCardCommand : Notifiable, ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageLarge { get; set; }
        public string ImageOriginal { get; set; }
        public string ImagePortrait { get; set; }
        public string ImageLandscape { get; set; }
        public string ImageTiny { get; set; }



        public void Validate()
        {
            AddNotifications(new Contract()
             .Requires()
             .HasMinLen(Title, 10, "Title", "O Title precisa ter mais do que 10 caracteres.")
             .HasMinLen(Description, 10, "Description", "A Description precisa ter mais do que 10 caracteres"));
        }
    }
}
