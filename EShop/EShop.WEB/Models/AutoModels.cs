using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.WEB.Models
{
    //ModelView для формы авторизации
    public class LoginModel
    {
        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

    }

    //ModelView для формы регистрации
    public class RegisterModel
    {
        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя пользователя*")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Имя должно состоять из 2 - 20 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль*")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Необходимо ввести возраст")]
        //закомментировать, чтобы положить сайт при регистрации
        [Range(13, 98, ErrorMessage = "Вам должно быть 13 лет")]
        [Display(Name = "Сколько вам лет?*")]
        public int Age { get; set; }
    }
}