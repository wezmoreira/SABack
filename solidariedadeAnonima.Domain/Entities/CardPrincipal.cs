namespace solidariedadeAnonima.Domain.Entities
{
    public class CardPrincipal : Entity
    {
        public CardPrincipal(string title, string description, string imageLarge, string imageOriginal, 
            string imagePortrait, string imageLandscape, string imageTiny)
        {
            Title = title;
            Description = description;
            ImageLarge = imageLarge;
            ImageOriginal = imageOriginal;
            ImagePortrait = imagePortrait;
            ImageLandscape = imageLandscape;
            ImageTiny = imageTiny;
            Date = DateTime.Now;
        }

        public User User { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageLarge { get; set; }
        public string ImageOriginal { get; set; }
        public string ImagePortrait { get; set; }
        public string ImageLandscape { get; set; }
        public string ImageTiny { get; set; }
        public DateTime Date { get; set; }
    }
}
