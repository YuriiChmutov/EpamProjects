using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EpamPractice.Models
{
    public class User
    {
        [Required(ErrorMessage = "Введите свое имя!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите краткое описание комментария!")]
        public string TitleOfComment { get; set; }

        public string Comment { get; set; }
        
        public DateTime Date { get; set; }

        public User() { }
        public User(string name, string title, string comment, DateTime date)
        {
            this.Comment = comment;
            this.Date = date;
            this.TitleOfComment = title;
            this.Name = name;
        }
    }
}