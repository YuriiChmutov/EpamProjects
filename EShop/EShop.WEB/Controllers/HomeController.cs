using EShop.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.DAL.EF;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using EShop.DAL.Repositories;

namespace EShop.WEB.Controllers
{
    public class HomeController : Controller
    {

        EFUnitOfWork unitOfWork;

        public HomeController()
        {
            unitOfWork = new EFUnitOfWork();
        }
        public ActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                Leaders = unitOfWork.Products.GetAll()
                        .OrderByDescending(p => p.Price)
                        .Take(4),

                Telephones = from p in unitOfWork.Products.GetAll()
                             where p.CategoryId == 1 || p.CategoryId == 2
                             select p

            };
                      
            return View(model);
        }

        //int pageSize = 3; // количество объектов на страницу
        //var phones = unit.Products.GetAll().ToList();
        //IEnumerable<Product> productsPerPages = phones.Skip((page - 1) * pageSize).Take(pageSize);
        //PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phones.Count };
        //IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Products = productsPerPages };
        //    return View(ivm);

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}