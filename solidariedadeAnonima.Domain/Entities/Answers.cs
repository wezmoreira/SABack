using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Domain.Entities
{
    public class Answers : Entity
    {
        public Answers(string comment, string image)
        {
            Comment = comment;
            Image = image;
            Date = DateTime.Now;
        }

        public User User { get; set; }
        public Guid UserId { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public Comments Comments { get; set; }
        public Guid CommentsId { get; set; }
        //public List<Comments> Comments { get; set; } = new List<Comments>(); // Mudar relacionamento
    }
}
