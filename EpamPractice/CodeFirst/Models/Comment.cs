using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    class Comment
    {
        public int CommentId { get; set; }
        public string TitleOfComment { get; set; }

        public string Text { get; set; }
    }
}
