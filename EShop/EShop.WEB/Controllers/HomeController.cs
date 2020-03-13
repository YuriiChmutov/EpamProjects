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
using EShop.WEB.Filters;

namespace EShop.WEB.Controllers
{
    public class HomeController : Controller
    {

        EFUnitOfWork unitOfWork;

        public HomeController()
        {
            unitOfWork = new EFUnitOfWork();
        }
        public ActionResult Index(string searchProduct)
        {
            if (!String.IsNullOrEmpty(searchProduct))
            {
                RedirectToAction("Index","Product");
            }
                string result = "Вы вошли на сайт как гость";
             
                if (User.Identity.IsAuthenticated)
                {
                
                result = "Вы вошли на сайт как " + User.Identity.Name;
                }

            ViewBag.Result = result;

            var model = new HomePageViewModel()
            {
                Leaders = unitOfWork.Products.GetAll()
                        .OrderByDescending(p => p.Price)
                        .Take(4),

                Telephones = unitOfWork.Products.GetAll()
                        .Where(p => p.CategoryId == 1)
                        .Take(8)
                    
            };
            
            
            return View(model);
        }

        
        

        
        
    }
}