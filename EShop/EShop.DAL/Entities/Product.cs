using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EShop.DAL.Entities
{
    public class Product
    {
        
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Введите название продукта")]
        [Display (Name = "Название")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)] //два символа после запятой отображается
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше 0")]

        public decimal Price { get; set; }
        [Display(Name = "Цвет")]

        public string Color { get; set; }
        [Display(Name = "Размер")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Размер должен быть больше 0")]
        public decimal Size { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        [Display(Name = "Категория")]
        public virtual Category Category { get; set; }

        public string ImagePath { get; set; }

        public int AmountOfPurchases { get; set; }

        //public virtual Picture Picture { get; set; }

        //public  ImageFile { get; set; }
    }
}
