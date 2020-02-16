using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class TagArticleModel
    {

       // public int TagToArticle { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}
