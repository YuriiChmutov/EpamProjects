using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpamPractice.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAll()
        {
            ViewBag.ProductList = "Это наш список продуктов";
            return View();
        }


        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(string name, string discription)
        {
            ViewBag.Return = $"{name}: {discription}";
            return View();
        }
    }
}