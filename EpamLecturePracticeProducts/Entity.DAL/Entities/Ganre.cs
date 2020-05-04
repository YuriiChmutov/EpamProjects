using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Entity.DLL.Entities
{
    public class Ganre
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Hello")]
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }

    
}