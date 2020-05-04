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
        [Display(Name ="Заголовк")]
        public string NameOfNews { get; set; }
        [Display(Name = "Особое")]
        public string Special { get; set; }
        [Display(Name = "Подзаголовок")]
        public string Subtitle { get; set; }
        [Display(Name = "Изображение")]
        public string Link { get; set; }
        [Required]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Содержимое")]
        public string Content { get; set; }
        [Display(Name = "Тэги")]
        public ICollection<Tag> Tags { get; set; }

        public Article()
        {
            Tags = new List<Tag>();
        }
    }
}
