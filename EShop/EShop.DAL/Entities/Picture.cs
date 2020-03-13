using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EShop.DAL.Entities
{
    public class Picture
    {
        public int Id { get; set; }
       

        //public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
