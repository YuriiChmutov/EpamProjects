using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CodeFirst.Models;
using EpamPractice.DAL;
using CodeFirst.Interfaces;
using EpamPractice.Util;
using EpamPractice.Repository;


namespace EpamPractice.Controllers 

{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork;
       // private BlogContext db1 = new BlogContext();
        IRepository<Article> db;
        //IRepository repo;

        //public HomeController(IRepository r)
        //{
        //this.repo = r;
        //}
        public HomeController()
        {
            unitOfWork = new UnitOfWork();
            db = new ArticleRepository();
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            //ViewBag.Votes = db1.Votes.ToList();
            //return View(db.GetArticleList());

            using (var d = new BlogContext())
            {
                var model = new HomeIndexModelView
                {
                    Articles = d.Articles.ToList(),
                    Votes = d.Votes.ToList(),
                   

                };

                ViewBag.Count = (from i in d.Votes select i.Amount).Sum();
                ViewBag.One = (from i in d.Votes where i.Id == 1 select i.Amount).Sum();
                ViewBag.Two = (from i in d.Votes where i.Id == 2 select i.Amount).Sum();
                ViewBag.Three = (from i in d.Votes where i.Id == 3 select i.Amount).Sum();


                int pageSize = 2; // количество объектов на страницу
                IEnumerable<Article> articlesPerPages = model.Articles.Skip((page - 1) * pageSize).Take(pageSize);
                PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = model.Articles.Count()};
                IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Articles = articlesPerPages };
                // ViewBag.ivm = ivm;

                model.IndexView = ivm;

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Index(Vote vote, string optionsRadios)
        {
            using (var d = new BlogContext())
            {
                var model = new HomeIndexModelView
                {
                    Articles = d.Articles.ToList(),
                    Votes = d.Votes.ToList()
                };
                if (optionsRadios == "1")
                {
                    Vote v = d.Votes.Find(1);
                    v.Amount++;
                    d.SaveChanges();
                }
                if (optionsRadios == "2")
                {
                    Vote v = d.Votes.Find(2);
                    v.Amount++;
                    d.SaveChanges();
                }
                if (optionsRadios == "3")
                {
                    Vote v = d.Votes.Find(3);
                    v.Amount++;
                    d.SaveChanges();
                }
                ViewBag.Count = (from i in d.Votes select i.Amount).Sum();
                ViewBag.One = (from i in d.Votes where i.Id == 1 select i.Amount).Sum();
                ViewBag.Two = (from i in d.Votes where i.Id == 2 select i.Amount).Sum();
                ViewBag.Three = (from i in d.Votes where i.Id == 3 select i.Amount).Sum();
                return View(model);
            } 
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList tags = new SelectList(unitOfWork.Tags.GetAll(), "Id", "Text");
            ViewBag.Tags = tags;
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, NameOfNews, Special,Subtitle,Content")]Article article)
        {
            article.Date = DateTime.Now;
            using(BlogContext context = new BlogContext())
            {
                if (ModelState.IsValid)
                {
                    context.Articles.Add(article);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            

            return View(article);
        }

        public ActionResult Details(int? id)
        {
            using (var context = new BlogContext())
            {
                var article = context.Articles.Find(id);
                if(article == null)
                {
                    return HttpNotFound();
                }
                //var post = context.Articles.Find(id);
                //context.Entry(post).Reference(p => p.Tags).Load();
                //context.Entry(post).Reference(p => p.Tags).Load();
                //context.Articles.Find(id).Tags.ToList()

                article = context.Articles
                       .Where(b => b.Id == id)
                       .Include(b => b.Tags)
                       .FirstOrDefault();

                ViewBag.article = unitOfWork.Articles.Get(id);

                return View(article);
            }
        }


        public ActionResult Delete(int? id)
        {
            
            Article article = unitOfWork.Articles.Get(id);
            
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using(BlogContext context = new BlogContext())
            {
               Article article = context.Articles.Find(id);
                //article = context.Articles
                //       .Where(b => b.Id == id)
                //       .Include(b => b.Tags)
                //       .FirstOrDefault();
                context.Articles.Remove(article);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            //Article article = unitOfWork.Articles.Get(id);
            
            
        }


        [HttpGet]
        public ActionResult ProfileShow()
        {

                ViewBag.Colors = new string[] { "askQuestion@mail.com", "+(380)-93-376-15-01", "@yuriiChmutov" };
                return View();  
        }

        [HttpPost]
        public ActionResult ProfileShow(string nameFromProfile, FormCollection form)
        {
           
            ViewBag.Return = $"{nameFromProfile}, вы заполнили анкету, спасибо!";
            return RedirectToAction("ProfileShowResults", "Home");
        }

        
        public ActionResult ProfileShowResults(FormCollection form, string optionsRadios)
        {
            StringBuilder res = new StringBuilder();

            if (form["nameFromProfile"] != "")
            {
                res.AppendLine($"{form["nameFromProfile"]}, вы заполнили анкету, спасибо!\n ");
            }
            else { res.AppendLine($"Жаль, что вы не написали как вас зовут, но вы заполнили анкету, спасибо!\n "); }
            if (form["lastNameFromProfile"] != "")
            {
                res.AppendLine($"\nВаша фамилия: {form["lastNameFromProfile"]}.");
            }
            
            res.AppendLine($" Ваш пол: {optionsRadios}.");
            //res.Append($"Были в Англии: {form["England"]}");
            if (form["England"] == "true") { res.Append($" Вы были в Англии, это круто! "); }
            else { res.AppendLine($" Вы не были в Англии, советую там побывать! "); }

            if (form["Canada"] == "true") { res.AppendLine($" Вы были в Канаде, а я нет. "); }
            if (form["Canada"] != "true"){ res.AppendLine($" Вы не были в Канаде, как и я. "); }
            if (form["Germany"] == "true") { res.AppendLine($" Вы были в Германии. "); }
            else { res.AppendLine($" Вы не были в Германии. "); }

            res.AppendLine($"Вы оценили мой блог {form["rate"]} балов, приходите еще.");
            ViewBag.Show = res;
            return View();
        }

       
    }
}