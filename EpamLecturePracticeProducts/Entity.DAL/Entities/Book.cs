using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entity.DLL.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Input name of Book!")]
        //[StringLength(20)]
        public string Title { get; set; }

        [Required(ErrorMessage ="Input author!")]
        //[StringLength(20, MinimumLength = 2)]
        public string Author { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage ="Input price!")]
        //[Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0.00")]
        //[RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Incorrect price")]
        public decimal Price { get; set; }

        //[DataType(DataType.Date.)]
        //[Range(4,4, ErrorMessage = "Input 4 symbols")]
        public int Year { get; set; }
       
        [Required]
        public int ISN { get; set; }
        public int GanreId { get; set; }
        public virtual Ganre Ganre { get; set; }

       
           
        
    }


   /* public class Books : IEnumerable<Book>
    {
        public List<Book> UsersList { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return UsersList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }*/


}