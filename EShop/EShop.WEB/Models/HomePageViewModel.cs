using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EShop.WEB.Models;
using EShop.DAL.Entities;
using EShop.DAL.EF;
using EShop.DAL.Repositories;
using EShop.DAL.Interfaces;

namespace EShop.WEB.Models
{
    //ModelView для главной страницы
    public class HomePageViewModel
    {
        public IEnumerable<Product> Leaders { get; set; }
        public IEnumerable<Product> Telephones { get; set; }
        public Product Product { get; set; }
        
    }
}