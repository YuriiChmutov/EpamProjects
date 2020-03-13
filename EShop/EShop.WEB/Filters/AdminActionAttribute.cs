using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.DAL.Entities;
using EShop.DAL.EF;
using System.Web.Security;
using System.Web.Routing;

namespace EShop.WEB.Filters
{
    /// <summary>
    /// Класс, для создания фильтра, который будет "намекать" 
    /// пользователю, который является гостем или просто юзером,
    /// что надо войти в аккаунт от имени админа
    /// </summary>
    public class AdminActionAttribute: FilterAttribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // не реализован
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //если уже авторизирован (от имени юзера)
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                var returnUrl = filterContext.HttpContext.Request["returnUrl"];
                //но еще не админ
                if (!Roles.IsUserInRole("admin"))
                {
                    //то осуществляется перенаправление на представление,
                    //которое предложит войти в аккаунт от имени админа
                    filterContext.Result =
                        new RedirectToRouteResult(new RouteValueDictionary
                        {
                            { "action", "Question" },
                            { "controller", "Account" },
                            { "returnUrl", returnUrl }
                        });
                }
            }
            else
            {
                //если еще не авторизован
                var returnUrl = filterContext.HttpContext.Request["returnUrl"];
                if (!Roles.IsUserInRole("admin"))
                {
                    filterContext.Result =
                        new RedirectToRouteResult(new RouteValueDictionary
                        {
                            { "action", "Question" },
                            { "controller", "Account" },
                            { "returnUrl", returnUrl }
                        });
                }
            }
        }
    }
}