using EShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.WEB.Models
{
    /// <summary>
    /// Для того, чтобы была возможность передать две части информации в представление, 
    /// которое будет отображать содержимое корзины:
    /// объект Корзина и URL-адрес для отображения,
    /// если пользователь нажимает кнопку «Продолжить покупки».
    /// </summary>
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}