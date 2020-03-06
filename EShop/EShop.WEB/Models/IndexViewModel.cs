using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EShop.DAL.Entities;
using EShop.DAL.EF;
using EShop.DAL.Interfaces;
using EShop.DAL.Repositories;

namespace EShop.WEB.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageInfo PageInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}