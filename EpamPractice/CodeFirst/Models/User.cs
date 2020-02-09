using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        
        public string TitleOfComment { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

        
    }
}
