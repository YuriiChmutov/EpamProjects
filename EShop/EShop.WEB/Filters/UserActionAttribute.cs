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
    /// Класс, для создания фильтра, который будет незарегестрированному
    /// пользователю "намекать", что надо войти в аккаунт
    /// </summary>
    public class UserActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // не реализован
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // если пользователь является гостем
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                var returnUrl = filterContext.HttpContext.Request["returnUrl"];
                // и если не в роли юзера (навсякий случай)
                if (!Roles.IsUserInRole("user") || Roles.IsUserInRole("ban"))
                {
                    //осуществляется перенаправление на представление, которое предложит войти в аккаунт
                    filterContext.Result =
                        new RedirectToRouteResult(new RouteValueDictionary
                        {
                            { "action", "QuestionUser" },
                            { "controller", "Account" },
                            { "returnUrl", returnUrl }
                        });
                }
            }
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                var returnUrl = filterContext.HttpContext.Request["returnUrl"];
                // и если не в роли юзера (навсякий случай)
                if (Roles.IsUserInRole("ban"))
                {
                    //осуществляется перенаправление на представление, которое предложит войти в аккаунт
                    filterContext.Result =
                        new RedirectToRouteResult(new RouteValueDictionary
                        {
                            { "action", "QuestionUser" },
                            { "controller", "Account" },
                            { "returnUrl", returnUrl }
                        });
                }
            }

        }
    }
}