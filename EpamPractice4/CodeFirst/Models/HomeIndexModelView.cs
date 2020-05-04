using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class HomeIndexModelView
    {
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<Vote> Votes { get; set; }
        public IndexViewModel IndexView { get; set; }

        //public IEnumerable<Article> Articles { get; set; }
        //public IEnumerable<Tag> Tags { get; set; }
    }
}
