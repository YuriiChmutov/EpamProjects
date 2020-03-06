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
    /// <summary>
    /// Контроллер для взаимодействия с корзиной
    /// Используется функция состояния сеанса ASP.NET для хранения и получения объектов корзины.
    /// ASP.NET имеет хорошую функцию сессии, которая использует
    /// файлы cookie или перезапись URL-адреса, чтобы связать несколько запросов
    /// от пользователя вместе для формирования одного сеанса просмотра.
    /// Связанной функцией является состояние сеанса, которое связывает данные с сеансом.
    /// Данные, связанные с сеансом удаляется, когда истекает срок сеанса.
    /// </summary>
    public class CartController : Controller
    {
        EFUnitOfWork unit;

        public CartController()
        {
            unit = new EFUnitOfWork();
        }

        //Не используется (был заменен Binding-ом)
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"]; //Добавить объект в состояние сеанса
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        //Передача представления корзины 
        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart, //GetCart()
                ReturnUrl = returnUrl
            });
        }

        //Данные приходят с ProductSummary.cshtml
        //Поштучное добавление предметов в корзину
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = unit.Products.Get(productId);

            if (product != null)
            {
                cart.AddItem(product, 1); //GetCart().
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        // Удаление предметов с корзины (сразу все с данным индексом)
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = unit.Products
            .Get(productId);
            if (product != null)
            {
                cart.RemoveLine(product); //GetCart()
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Частичное представление для того, чтобы отображать в навбаре
        /// кол-во предметов в корзине и сумму покупки
        /// </summary>        
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        //Передача представления оформления заказа
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        //Отправяем заказ
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Ваша корзина пустая!");
            }
            if (ModelState.IsValid)
            {
                //orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}