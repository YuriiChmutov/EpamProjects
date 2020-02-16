using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string NameOfNews { get; set; }
        public string Special { get; set; }
        public string Subtitle { get; set; }
        public string Link { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public Article()
        {
            Tags = new List<Tag>();
        }
    }
}
