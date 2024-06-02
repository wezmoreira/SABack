using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Domain.Entities
{
    public class Comments : Entity
    {
        public Comments(string comment, string image)
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
        public List<Answers> Answers { get; set; } = new List<Answers>();
    }
}
