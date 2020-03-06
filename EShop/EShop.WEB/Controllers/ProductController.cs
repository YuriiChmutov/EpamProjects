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
    public class ProductController : Controller
    {
        EFUnitOfWork unit;
        public int PageSize = 4;
        public ProductController()
        {
            unit = new EFUnitOfWork();
        }

        // GET: Product
        public ViewResult Index(string category, int page = 1)
        {
            IndexViewModel model = new IndexViewModel
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
            return View(model);
        }

        public ViewResult IndexAdmin()
        {
            return View(unit.Products.GetAll().ToList());
        }

        // GET: Product/Details/5
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

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,Description,Price,Color,Size,Date,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                //db.Products.Add(product);
                //db.SaveChanges();
                unit.Products.Create(product);
                unit.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Product/Edit/5
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

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Description,Price,Color,Size,Date,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                unit.Products.Update(product);
                unit.Save();
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Product/Delete/5
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

        // POST: Product/Delete/5
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
