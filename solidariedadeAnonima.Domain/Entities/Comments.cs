namespace solidariedadeAnonima.Domain.Entities
{
    public class Comments : Entity
    {
        public Comments()
        {
            
        }

        public Comments(string comment, Guid user, Guid card)
        {
            Comment = comment;
            UserId = user;
            CardPrincipalId = card;
            Date = DateTime.Now;
        }

        public User User { get; set; }
        public Guid UserId { get; set; }
        public CardPrincipal Card { get; set; }
        public Guid CardPrincipalId { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        //public List<Answers> Answers { get; set; } = new List<Answers>();
    }
}
