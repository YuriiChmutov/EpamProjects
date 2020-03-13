using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShop.DAL.EF;
using EShop.DAL.Entities;
using EShop.DAL.Repositories;
using EShop.WEB.Models;

namespace EShop.WEB.Controllers
{
    public class NavController : Controller
    {
        private EFUnitOfWork unit;

        public NavController()
        {
            unit = new EFUnitOfWork();
        }

        //частичное представление бокового меню
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = unit.Categories.GetAll().ToList()
            .Select(x => x.Name)
            .Distinct()
            .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}