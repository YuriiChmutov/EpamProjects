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
using System.IO;
using EShop.WEB.Filters;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;

namespace EShop.WEB.Controllers
{
    [AdminAction]
    public class AdministrationController : Controller
    {
        //создание приватной пременной, которая отвечает за взаимодействие с бд
        EFUnitOfWork unit;

        //публичный конструктор класса, для взаимодейсвия с переменной
        public AdministrationController()
        {
            unit = new EFUnitOfWork();
        }

        

        //возвращаю представление отображения списка продуктов магазина
        [ExceptionLogger]
        public ActionResult Index(string sortOrder, string SearchString)
        {
            //параметры для сортировки списка
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "Id_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";
            var products = unit.Products.GetAll().ToList();

            //если что-то ввести в посковую строку, то поиск осуществится по имени, категории
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.OrderBy(p => p.Name).Where(p => p.Name.ToLower().Contains(SearchString.ToLower())
                                || p.Category.Name.ToLower().Contains($"{SearchString.ToLower()}")).ToList();
            }                     

            //переключение между параметрами сортировки
            //плюс передаются HTML символы в десятичной системе (например, стрелочка вниз/вверх)
            switch (sortOrder)
            {
                //время добавления в бд по убыванию
                case "Id_desc":
                    ViewBag.PictureId = String.Format("&#9660;");
                    ViewBag.PictureName = String.Format("&#8801");
                    ViewBag.PicturePrice = String.Format("&#8801");
                    products = products.OrderByDescending(p => p.ProductId).ToList();
                    break;
                //по имени по алфавиту
                case "name":
                    ViewBag.PictureId = String.Format("&#8801");
                    ViewBag.PicturePrice = String.Format("&#8801");
                    ViewBag.PictureName = String.Format("&#9650");
                    products = products.OrderBy(p => p.Name).ToList();
                    break;
                //по имени с конца алфавита
                case "name_desc":
                    ViewBag.PictureId = String.Format("&#8801");
                    ViewBag.PicturePrice = String.Format("&#8801");
                    ViewBag.PictureName = String.Format("&#9660");
                    products = products.OrderByDescending(p => p.Name).ToList();
                    break;
                //по цене по возрастанию
                case "Price":
                    ViewBag.PictureId = String.Format("&#8801");
                    ViewBag.PicturePrice = String.Format("&#9650");
                    ViewBag.PictureName = String.Format("&#8801");
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                //по цене по убыванию
                case "price_desc":
                    ViewBag.PictureId = String.Format("&#8801");
                    ViewBag.PicturePrice = String.Format("&#9660");
                    ViewBag.PictureName = String.Format("&#8801");
                    products = products.OrderByDescending(p => p.Price).ToList();
                    break;
                //по-умолчанию по очереди добавления в бд
                default:
                    products = products.OrderBy(p => p.ProductId).ToList();
                    ViewBag.PictureId = String.Format("&#9650;");
                    ViewBag.PictureName = String.Format("&#8801");
                    ViewBag.PicturePrice = String.Format("&#8801");
                    break;
            }
            return View(products);
        }

        //возвращаю представление подробной информации об продукте
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

        //возвращаю представление создания нового продукта       
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name");
            return View();
        }

        //сохраняю в бд новый продукт        
        [HttpPost]
        [ExceptionLogger]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase ImageFile = null)
        {
            
                if (ImageFile == null)
                {
                    ModelState.AddModelError("", "Пустой файл");
                }
                
                if (ImageFile.ContentLength > 1 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "Большой файл");
                }
            try
            {
                if  (Image.FromStream(ImageFile.InputStream).RawFormat.Equals(ImageFormat.Jpeg) == false)
                {
                    ModelState.AddModelError("", "Не JPEG");
                }
            }
            catch { }
            
        
            //ModelState.AddModelError("", "Не тот файл");

            if (ModelState.IsValid)
            {
                //добавление фотографии для продукта
                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                //берем расположение файла
                string extension = Path.GetExtension(ImageFile.FileName);
                //создаю для файла уникальное имя
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //куда созранять (путь для бд)
                product.ImagePath = "~/Content/Images/" + fileName;
                //сохранение файла в папку в проекте
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                //сохраняю как
                ImageFile.SaveAs(fileName);

                //byte[] imageData = null;
                //// считываем переданный файл в массив байтов
                //using (var binaryReader = new BinaryReader(ImageFile.InputStream))
                //{
                //    imageData = binaryReader.ReadBytes(ImageFile.ContentLength);
                //}
                //// установка массива байтов
                //product.Image = imageData;

                unit.Products.Create(product);
                unit.Save();
                //чтобы передать в алерт уведомление о том, что продукт был добавлен успешно                
                TempData["messageCreate"] = string.Format($"{product.Name} был добавлен!");
                
                return RedirectToAction("Index", "Administration");
            }
            


            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        
        //возвращаю представление изменения параметров для конкретного продукта
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

        //сохраняю новые данные для продукта
        [HttpPost]
        [ExceptionLogger]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Description,Price,Color,Size,Date,CategoryId")]Product product,
            HttpPostedFileBase ImageFile = null) { 
            if (product.Date > DateTime.Now.Date)
            {
                ModelState.AddModelError("Date", "Дата не может быть больше сегодняшней!");
            }
            if (product.Date.Year < 1970)
            {
                ModelState.AddModelError("Date", "Не раньше 1970г.");
            }
           
            if (ModelState.IsValid)
            {
                //добавление фотографии для продукта
                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);                
                //берем расположение файла
                string extension = Path.GetExtension(ImageFile.FileName);
                //создаю для файла уникальное имя
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //куда созранять (путь для бд)
                product.ImagePath = "~/Content/Images/" + fileName;
                //сохранение файла в папку в проекте
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                //сохраняю как
                ImageFile.SaveAs(fileName);

                unit.Products.Update(product);
                unit.Save();
                TempData["message"] = string.Format($"{product.Name} сохранено!");
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(unit.Categories.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        //возвращает представление предложения удалить продукт
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

        //удаление продукта
        [HttpPost, ActionName("Delete")]
        [ExceptionLogger]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = unit.Products.Get(id);            
            unit.Products.Delete(id);            
            unit.Save();
            
            TempData["messageDelete"] = string.Format($"{product.Name} был удален!");
            return RedirectToAction("Index");
        }

        //возвращает представление списка возникших исключений
        public ActionResult ExceptionsInfo()
        {
            using(EShopContext context = new EShopContext())
            {
                return View(context.ExceptionDetails.ToList());
            }
        }

        //осуществляется зачистка исключений из бд (данные реально удаляются)
        [HttpPost]
        public ActionResult ExceptionsInfo(string t)
        {
            using(EShopContext db = new EShopContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [ExceptionDetail]");
                db.SaveChanges();
                
            }
            return RedirectToAction("ExceptionsInfo");
        }

        //отображение списка зарегестрированных пользователей кроме админа
        public ActionResult CheckUsers(string SearchUser)
        {
            var user = unit.Users.GetAll()
                .ToList().Where(u => u.RoleId == 2 || u.RoleId == 3);

            if (!String.IsNullOrEmpty(SearchUser))
            {
                user = user.Where(u => u.Email.ToLower().Contains($"{SearchUser.ToLower()}")
                                || (u.Age).ToString() == SearchUser
                                && (u.RoleId == 2 || u.RoleId == 3)).ToList();
            }

            return View(user);
        }

        //обращение к пользователю
        public ActionResult ChangeUsers(int? id)
        {
            User user = unit.Users.Get(id);
            if (id == null)
            {
                return HttpNotFound();
            }


            return View(user);
        }

        //забанить или разбанить пользователя
        [HttpPost, ActionName("ChangeUsers")]
        public ActionResult ChangeUsersConfirmed(int id)
        {
            User user = unit.Users.Get(id);
            //если зарегестрирован, то отправить в бан
            if (user.RoleId == 2)
            {
                user.RoleId = 3;
                
            }
            //если забанен, разбанить
            else if (user.RoleId == 3)
            {
                user.RoleId = 2;
                
            }
            unit.Users.Update(user);
            unit.Save();
            return RedirectToAction("CheckUsers", "Administration");
        }

        //список всех заказов
        public ActionResult ListOfOrders(string userName)
        {
            var orders = unit.Orders.GetAll().ToList();
            //поиск заказов конкретного пользователя
            if (!String.IsNullOrEmpty(userName))
            {
                orders = orders.Where(o => o.User.Email.Contains(userName)).ToList();
            }
            return View(orders);
        }

        //представление формы изменения параметров заказа
        public ActionResult EditOrder(int? id)
        {
            var order = unit.Orders.Get(id);
            if(order == null)
            {
                HttpNotFound();
            }
            return View(order);
        }


        //пост форма измененения параметров формы заказа
        [HttpPost]
        public ActionResult EditOrder(Order order, string StatusOrder )
        {
            
            if (String.IsNullOrEmpty(StatusOrder))
            {
                //StatusOrder = unit.Orders.Get(order.Id).Status.FirstOrDefault().ToString();
                ModelState.AddModelError("StatusOrder", "Нужно выбрать статус");
            }
            if (ModelState.IsValid)
            {
                
                order.Status = StatusOrder;              
                
                order.Date = DateTime.Now;
                unit.Orders.Update(order);
                unit.Save();
               // TempData["messageChangeOrder"] = string.Format($"Статус заказа был изменен на {order.Status}!");
                return RedirectToAction("ListOfOrders");
            }
            return View(order);
        }


        //закрыть соединение с бд
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
