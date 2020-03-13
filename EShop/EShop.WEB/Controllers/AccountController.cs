using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.WEB.Models;
using EShop.DAL.Entities;
using EShop.DAL.EF;
using System.Web.Security;
using EShop.WEB.Filters;
using EShop.DAL.Repositories;

namespace EShop.WEB.Controllers
{
    public class AccountController : Controller
    {
        //создание приватной пременной, которая отвечает за взаимодействие с бд
        EFUnitOfWork unit;
        
        //публичный конструктор класса, для взаимодейсвия с переменной
        public AccountController()
        {
            unit = new EFUnitOfWork();
        }

        //представление формы регистрации
        public ActionResult Register()
        {
            return View();
        }


        //пост форма регистрации (создаю нового пользователя сайта, по-умолчанию это user)
        [HttpPost]
        [ExceptionLogger]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            //чтобы "положить" сайт для проверки корректности работы журналирования ошибок
            //(надо еще в ~Models/AutoModels/RegisterModel закомментировать атрибут [Range(13, 98, ErrorMessage = "Вам должно быть 13 лет")]
            if (model.Age > 98)
            {
                try
                {
                    throw new Exception("Слишком большой возраст");
                }
                catch
                {
                    ModelState.AddModelError("Age", "Слишком большой возраст");
                }            

            }
            if(model.Age == 155)
            {
                throw new Exception("Был введен возраст 155");
            }

            //форма прошла валидацию?
            if (ModelState.IsValid)
            {
                User user = null;
                //использую данный способ взаимодейсвия с бд в качестве демонстрации (ПЛОХОЙ ТОН)
                using(EShopContext _context = new EShopContext())
                {
                    //проверка нет ли такого пользователя уже в бд
                    user = _context.Users.FirstOrDefault(u => u.Email == model.Name);
                }
                //если его нет
                if(user == null)
                {
                    using (EShopContext _context = new EShopContext())
                    {
                        //то создаем его
                        _context.Users.Add(new User { Email = model.Name, Password = model.Password, Age = model.Age, RoleId = 2 });
                        //новый пользователь при регистрации будет иметь по умолчанию роль user
                        _context.SaveChanges();
                        //и сразу же заходим в систему
                        user = _context.Users.Where(u => u.Email == model.Name && u.Password == model.Password).FirstOrDefault();
                    }
                    //заходим в систему
                    if(user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с данным логином уже существует!");
                    //Раскомментировать для проверки работы логирования
                    //throw new Exception("Попытка зарегестрировать уже существующий аккаунт");
                }
            }
            return View(model);
        }


        //представление для входа в систему
        [HttpGet]        
        public ActionResult Login()
        {            
            return View();
        }

        //пост форма входа в систему
        [HttpPost]
        [ExceptionLogger]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            //данные прошли валидацию?
            if (ModelState.IsValid)
            {
                User user = null;
                //использую данный способ взаимодейсвия с бд в качестве демонстрации (ПЛОХОЙ ТОН)
                using (EShopContext _context = new EShopContext())
                {
                    //ищу пользователя с таким именем и паролем
                    user = _context.Users.FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);
                }

                //нашли? входим в систему
                if(user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                
                //иначе возвращаем форму с валидацией
                else
                {
                    ModelState.AddModelError("", "Неверно введенные данные");
                    //Раскомментировать для проверки работы логирования
                    //throw new Exception("Неверно введенные данные");

                }
            }
            return View(model);
        }

        //представление для подтверждения выхода из системы
        public ActionResult Exit()
        {            
            return View();
        }


        //пост форма для подтверждения выхода из системы
        [HttpPost]
        public ActionResult Exit(LoginModel model, Cart cart)
        {
            //чистим корзину
            cart.Clear();
            //выходим из сессии
            FormsAuthentication.SignOut();
            //пресылаем на форму регистрации
            return RedirectToAction("Login", "Account");
        }

        //частичное представление кнопки "войти||выйти"
        public PartialViewResult IsAuthorised()
        {
            return PartialView();
        }

        //представление уведомления а том, что нет прав администратора
        //вызываю в ~Filters/AdminActionAttribute.cs
        public ActionResult Question(string returnUrl)
        {
            //чтобы была возможность вернуться на последнюю страницу по URL
            if (returnUrl != null)
            {
                var segments = returnUrl.Split('/');
                ViewBag.Controller = segments[1]; ViewBag.Action = segments[2];
            }
            else
            {
                ViewBag.Controller = "Home"; ViewBag.Action = "Index";
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        //представление уведомления а том, что необходимо войти в систему, для выполнения действия
        //вызываю в ~Filters/UserActionAttribute.cs
        public ActionResult QuestionUser(string returnUrl)
        {
            //чтобы была возможность вернуться на последнюю страницу по URL
            if (returnUrl != null)
            {
                var segments = returnUrl.Split('/');
                ViewBag.Controller = segments[1]; ViewBag.Action = segments[2];
            }
            else
            {
                ViewBag.Controller = "Home"; ViewBag.Action = "Index";
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        //представление списка заказов пользователя
        [UserAction]
        public ActionResult OrdersList()
        {
            //поиск заказов для текущего пользователя
            var orders = unit.Orders.GetAll().ToList()
                .Where(o => o.Name == User.Identity.Name && o.Visible == true);
            return View(orders);
        }

        //пост форма представления списка заказов
        //с ее помощью пользователь имеет возможность очистить список своих заказов,
        //но список не будет удален из бд, будет скрыт от пользователя
        [HttpPost]
        public ActionResult OrdersList(Order order)
        {
            var orders = unit.Orders.GetAll().ToList()
                .Where(o => o.Name == User.Identity.Name && o.Visible == true);

            foreach (var item in orders)
            {
                item.Visible = false;
            }
            unit.Save();

            return RedirectToAction("OrdersList");
        }
    }
}