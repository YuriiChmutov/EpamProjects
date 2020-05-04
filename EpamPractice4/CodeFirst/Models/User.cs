using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string TitleOfComment { get; set; }

        public string Comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        
    }
}
