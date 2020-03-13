using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EShop.DAL.Entities;
using EShop.DAL.EF;
using EShop.DAL.Repositories;
using System.Web.Mvc;


namespace EShop.WEB.Filters
{
    public class ExceptionLoggerAttribute : FilterAttribute, IExceptionFilter
    {
        //С помощью переданного в метод OnException() объекта ExceptionContext
        //получаем всю необходимую информацию об исключении, формируем объект ExceptionDetail
        //и сохраняем его в базу данных.
        public void OnException(ExceptionContext filterContext)
        {
            ExceptionDetail exceptionDetail = new ExceptionDetail()
            {
                ExceptionMessage = filterContext.Exception.Message,
                StackTrace = filterContext.Exception.StackTrace,
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                Date = DateTime.Now
            };

            using (EShopContext db = new EShopContext())
            {
                db.ExceptionDetails.Add(exceptionDetail);
                db.SaveChanges();
            }

            filterContext.ExceptionHandled = true;
        }
    }
}