using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EShop.DAL.Entities;
using System.Web.Mvc;

namespace EShop.WEB.Infrastructure.Binders
{
    /// <summary>
    /// Кдасс для создания сессии корзины покупок
    /// Так же класс теперь является Binder-ом (Global.asax)
    /// </summary>
    public class CartModelBinder: IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
        {
            // взять Cart из сессии
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }
            // создать Cart, если он не существует в данных сессии
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            
            return cart;
        }
    }
}