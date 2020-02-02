using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using EpamPractice.Models;
using System.Text;

namespace EpamPractice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public Users users = new Users
        {
            UsersList = new List<User>
                {
                    new User{Name = "Колян",TitleOfComment = "Это шедевр!", Comment = "Как здорово, что вообще такие блоги есть! Благодаря им мы смогли спланировать свое первое самостоятельное путешествие. Советы блогеров бесценны, потому как при планировании поездки есть много вопросов, а вот ответы часто не удовлетворяют, а блог-это способ выразить свое мнение и отразить существующую действительность.", Date = DateTime.Now},
                    new User{Name = "Мария",TitleOfComment = "Очень познавательно", Comment = "Буду рада, если мой блог о путешествиях тоже понравится 8) — chemezova.ru/travel/ Пишу про Байкал, Европу и Азию", Date = DateTime.Now},
                    new User{Name = "Саша",TitleOfComment = "Какие планы?", Comment = "Юрий, а если бы вы начинали свое путешествие и свой блог сегодня, сейчас, в какую страну вы бы отправились и почему?", Date = DateTime.Now},
                    new User{Name = "Ксения",TitleOfComment = "Если что", Comment = "А мне нравится авторский блог путешественника Алексея Гуреева landsurveyorsblog.org очень интересно написаны обзоры, статьи, много интересных, качественных фотографий, в общем рекомендую.", Date = DateTime.Now}

                }
        };

        [HttpGet]
        public ActionResult Comments()
        {
            
            //ViewBag.UserCollection = users;
            return View(users);
        }

        [HttpPost]
        public ViewResult Comments(string name, string title, string comment)
        {
            users.UsersList.Add(new User { Name = name, TitleOfComment = title, Comment = comment, Date = DateTime.Now});
            //ViewBag.UserCollection = users;
            return View(users);
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