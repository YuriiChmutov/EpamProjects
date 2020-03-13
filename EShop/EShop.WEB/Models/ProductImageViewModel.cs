using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EShop.DAL.Entities;
using EShop.WEB.Filters;

namespace EShop.WEB.Models
{
    public class ProductImageViewModel
    {
        
        [ValidateFile(ErrorMessage = "Выберите PNG или JPEG файл меньше 1МБ")]
        public HttpPostedFileBase File { get; set; }
    }
}