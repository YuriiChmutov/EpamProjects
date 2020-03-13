using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }
        
        public DateTime Date { get; set; }

        public bool Visible { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
