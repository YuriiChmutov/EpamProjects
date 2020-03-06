using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EShop.DAL.EF;
using EShop.DAL.Entities;
using EShop.DAL.Repositories;
using EShop.WEB.Models;
using System.Net;



namespace EShop.WEB.Controllers
{
    public class AdministrationController : Controller
    {
        EFUnitOfWork unit;

        public AdministrationController()
        {
            unit = new EFUnitOfWork();
        }

        // GET: Administration
        public ActionResult Index(string sortOrder, string SearchString)
        {
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "Id_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";
            var products = unit.Products.GetAll().ToList();

            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.OrderBy(p => p.Name).Where(p => p.Name.ToLower().Contains(SearchString.ToLower())
                                || p.Category.Name.ToLower().Contains($"{SearchString.ToLower()}")).ToList();
            }

            

            switch (sortOrder)
            {
                case "Id_desc":
                    ViewBag.PictureId = String.Format("&#9660;");
                    ViewBag.PictureName = String.Format("&#8801");
                    ViewBag.PicturePrice = String.Format("&#8801");
                    products = products.OrderByDescending(p => p.ProductId).ToList();
                    break;
                case "name":
                    ViewBag.PictureId = String.Format("&#8801");
                    ViewBag.PicturePrice = String.Format("&#8801");
                    ViewBag.PictureName = String.Format("&#9650");
                    products = products.OrderBy(p => p.Name).ToList();
                    break;
                case "name_desc":
                    ViewBag.PictureId = String.Format("&#8801");
                    ViewBag.PicturePrice = String.Format("&#8801");
                    ViewBag.PictureName = String.Format("&#9660");
                    products = products.OrderByDescending(p => p.Name).ToList();
                    break;
                case "Price":
                    ViewBag.PictureId = String.Format("&#8801");
                    ViewBag.PicturePrice = String.Format("&#9650");
                    ViewBag.PictureName = String.Format("&#8801");
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                case "price_desc":
                    ViewBag.PictureId = String.Format("&#8801");
                    ViewBag.PicturePrice = String.Format("&#9660");
                    ViewBag.PictureName = String.Format("&#8801");
                    products = products.OrderByDescending(p => p.Price).ToList();
                    break;
                default:
                    products = products.OrderBy(p => p.ProductId).ToList();
                    ViewBag.PictureId = String.Format("&#9650;");
                    ViewBag.PictureName = String.Format("&#8801");
                    ViewBag.PicturePrice = String.Format("&#8801");
                    break;
            }
            return View(products);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = unit.Products.Get(id);            
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Administration/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name");
            return View();
        }

        // POST: Administration/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {               
                unit.Products.Create(product);
                unit.Save();
                TempData["messageCreate"] = string.Format($"{product.Name} был добавлен!");
                
                return RedirectToAction("Index", "Administration");
            }

            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Administration/Edit/5
        public ActionResult Edit(int? id)
        {
            
            Product product = unit.Products.Get(id); 
            
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Administration/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Description,Price,Color,Size,Date,CategoryId")] Product product)
        {
            if(product.Date > DateTime.Now.Date)
            {
                ModelState.AddModelError("Date", "Дата не может быть больше сегодняшней!");
            }
            if (product.Date.Year < 1970)
            {
                ModelState.AddModelError("Date", "Не раньше 1970г.");
            }
            if (ModelState.IsValid)
            {
                unit.Products.Update(product);
                unit.Save();
                TempData["message"] = string.Format($"{product.Name} сохранено!");
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Administration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = unit.Products.Get(id);
            //Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Administration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = unit.Products.Get(id);
            //Product product = db.Products.Find(id);
            unit.Products.Delete(id);
            //db.Products.Remove(product);
            unit.Save();
            //db.SaveChanges();
            TempData["messageDelete"] = string.Format($"{product.Name} был удален!");
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
