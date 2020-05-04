using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public ICollection<Article> Articles { get; set; }
        public Tag()
        {
            Articles = new List<Article>();
        }
    }
}
