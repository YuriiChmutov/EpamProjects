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
using EShop.WEB.Filters;

namespace EShop.WEB.Controllers
{
    
    public class ProductController : Controller
    {
        EFUnitOfWork unit;
        public int PageSize = 4;
        public ProductController()
        {
            unit = new EFUnitOfWork();
        }

        //все товары с использованием пагинации (4 продукта на странице)
        public ViewResult Index(string category, string searchProduct, int page = 1)
        {
            IndexViewModel model;
            if (!String.IsNullOrEmpty(searchProduct))
            {
                model = new IndexViewModel
                {
                    Products = unit.Products.GetAll().ToList()
                 .Where(p => p.Name.ToLower().Contains($"{searchProduct.ToLower()}")
                 || p.Category.Name.ToLower().Contains($"{searchProduct.ToLower()}"))
                 .Skip((page - 1) * PageSize)
                 .Take(PageSize),
                    PageInfo = new PageInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = unit.Products.GetAll().Where(p => p.Name.ToLower().Contains($"{searchProduct.ToLower()}")).Count()
                        
                    },
                    CurrentCategory = category
                };
            }
            else
            {
                model = new IndexViewModel
                {
                    Products = unit.Products.GetAll().ToList()
                    .Where(p => category == null || p.Category.Name == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PageInfo = new PageInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ?
                           unit.Products.GetAll().Count() :
                           unit.Products.GetAll().ToList().Where(e => e.Category.Name == category).Count()
                    },
                    CurrentCategory = category
                };
            }
           
            return View(model);
        }

        
        public ViewResult IndexAdmin()
        {
            return View(unit.Products.GetAll().ToList());
        }

        //подробнее о конкретном продукте
        public ActionResult Details(int? id)
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

        //форма создания нового продукта
        public ActionResult Create()
        {
            //выпадающий список категорий товаров
            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name");
            return View();
        }

        //новый продукт заносится в бд
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,Description,Price,Color,Size,Date,CategoryId")] Product product)
        {
            //данные верные?
            if (ModelState.IsValid)
            {
                //создаю
                unit.Products.Create(product);
                unit.Save();
                return RedirectToAction("Index");
            }
            //иначе возвращаю форму создания
            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        //аналогия созданию
        public ActionResult Edit(int? id)
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
            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Description,Price,Color,Size,Date,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                unit.Products.Update(product);
                unit.Save();
                
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        
        public ActionResult Delete(int? id)
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

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = unit.Products.Get(id);            
            unit.Products.Delete(id);           
            unit.Save();
            
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
