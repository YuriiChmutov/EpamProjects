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
namespace EpamPractice.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext db = new BlogContext();
        public ActionResult Index()
        {
            return View();
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