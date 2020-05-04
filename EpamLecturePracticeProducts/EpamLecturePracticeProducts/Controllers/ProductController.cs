using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpamLecturePracticeProducts.DAL;
using Entity.DLL.Entities;
using Entity.DLL.Interfaces;
using EpamLecturePracticeProducts.Repository;
using System.Data.Entity;
using Entity.DAL.Entities;
using EpamLecturePracticeProducts.Util;


namespace EpamLecturePracticeProducts.Controllers
{
    public class ProductController : Controller
    {
        BookContext db1 = new BookContext();
        IRepository<Book> db;
        //IRepository<Book> repo;
        List<Book> booksList;
        //IRepository<Ganre> dbGanre = new GanreRepository();
        //BookContext dbG = new BookContext();

        //public ProductController(IRepository<Book> r)
        //{
            
        //    repo = r;
           
        //    // dbGanre = new GanreRepository();

        //}

        public ProductController()
        {
            db = new BookRepository();
            booksList = new List<Book>();
            booksList.Add(db.GetBook(1));
            booksList.Add(db.GetBook(2));
            booksList.Add(db.GetBook(3));
            booksList.Add(db.GetBook(4));

        }

        // private BookContext db = new BookContext();
        // GET: Product
        public ActionResult Index(int page = 1)
        {
            int pageSize = 3;
            IEnumerable<Book> booksPerPages = db.GetBookList().Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = booksList.Count };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Books = booksPerPages };
            return View(ivm);
        }

       [HttpGet]
        public ActionResult ShowAll()
        {
           using(BookContext context = new BookContext())
            {
                return View(context.Books.ToList());
            }
            
            
        }
        
        [HttpPost]
        public ActionResult ShowAll(string idBook)
        {
            
            //string text = "That is my list of products";
            //ViewBag.Text = "That is my list of products";
            //int number = 33;
            // var toReturn = from b in ListOfBooks where b.Id == id select b;
            //var book = ListOfBooks.FirstOrDefault(p => p.Id == idBook);
            //ViewBag.ganre = book.Ganre;
            //ViewBag.Books = toReturn;

            return View();
        }


       
        [HttpGet]
        public ActionResult AddProduct()
        {
            SelectList ganres = new SelectList(db1.Ganres, "Id", "Title");
            ViewBag.Ganres = ganres;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Book book)
        {
            if (book.Price <= 0)
            {
                ModelState.AddModelError("Price", "Price have be more then 0");
                
            }
            if(book.Year > DateTime.Now.Year || book.Year < 0)
            {
                ModelState.AddModelError("Year", $"Year can`t be bigger than {DateTime.Now.Year} or less than 0!");
                
            }
            if (ModelState.IsValid && book.Price >= 0)
            {
                db.Create(book);
                db.Save();
                return RedirectToAction("ShowAll");
            }

            SelectList ganres = new SelectList(db1.Ganres, "Id", "Title");
            ViewBag.Ganres = ganres;
            return View(book);
        }

        [HttpGet]
        public ActionResult AddGanre()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGanre([Bind(Include = "Title, Description")]Ganre ganre)
        {
            //if (string.IsNullOrEmpty(ganre.Title))
            //{
            //    ModelState.AddModelError("Title", "Input title!");
            //}

            if (ModelState.IsValid)
            {
                //dbGanre.Create(ganre);
                db1.Ganres.Add(ganre);
                db1.SaveChanges();
                return RedirectToAction("ShowAll");
            }


            return View(ganre);
        }

        public ActionResult Details(int? id)
        {
            Book book = db.GetBook(id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

       
        public ActionResult Delete(int id)
        {
            Book book = db.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            db.Save();
            return RedirectToAction("ShowAll");
        }

        
        public ActionResult Edit(int id)
        {
            Book book = db.GetBook(id);
            SelectList ganres = new SelectList(db1.Ganres, "Id", "Title", book.GanreId);
            ViewBag.Ganres2 = ganres;
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
           
            if (ModelState.IsValid)
            {
                db.Update(book);
                
                db.Save();
                return RedirectToAction("ShowAll");
            }
            return View(book);
        }

        public ActionResult ShowResult(int id)
        {
            
            return View();
        }
    }
}